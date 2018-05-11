/*
* PDM NexDome Shutter kit firmware. NOT compatible with original NexDome ASCOM driver or Rotation kit firmware.
*
* Copyright � 2018 Patrick Meloy
* Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
*  files (the �Software�), to deal in the Software without restriction, including without limitation the rights to use, copy,
*  modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software
*  is furnished to do so, subject to the following conditions:
*  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*
*  THE SOFTWARE IS PROVIDED �AS IS�, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
*  OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
*  BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF
*  OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*
*  Inspired by the original official NexDome firmware by grozzie2 but completely incompatible.
*  https://github.com/grozzie2/NexDome
*/


/*
** Basic operation
** On startup the shutter sends messages to the rotator with all the relevant data such as acceleration, timeouts, etc. Rotator also
** asks for this information if it's powered up after the shutter and missed the information.
**
** From there it just sits doing nothing until a command is received. Rather than have the rotator ask for updates, shutter will simply
** spew out updates to changing values while it is moving so the rotator is never out of sync with what the shutter is doing. This may
** sound like a lot of traffic but the values are pretty much all short strings so it doesn't even approach the limit of 9600 baud.
**
** One of the drawbacks of a "dumb" stepper driver is that if the Arduino is doing something else the stepper is not updated causing
** it to try and stop during a move. This doesn't last long but it does create a noticable "tick" sound. Each time it ticks there is 
** extra stress on the motor and gearing so reducing the ticking by not having to receive lots of update requests as well as sending
** them is a good thing.
**
** I'm also going to attempt to stagger the sending over the interval period rather than all in one scan which may eliminate the ticking.
**
** The rotator stores all received data in its RemoteShutter object and applications poll it rather than the shutter. This scheme lets
** the shutter be completely dormant until it receives a command, allowing its radio to sleep. I'll also look into putting the arduino
** to sleep which would save a lot more power.
*/

#include <AccelStepper.h>
#include <EEPROM.h>
#include "PDMShutterClass.h"

#define Computer Serial
String computerBuffer;

#define Wireless Serial1
String wirelessBuffer;

const String version = "0.5.1.0";

// Stepper motor configuration
#pragma endregion


#pragma region Global Enums


//<SUMMARY>Possible states the shutter could be in - default SS_ERROR at startup</SUMMARY>

//<SUMMARY>Whether the shutter has homeded and gone full stroke</SUMMARY>
enum HomeStatuses { HS_NONE, HS_SYNC, HS_DONE };

#pragma endregion

#pragma region Command character constants
// x_CMD is the comand itself, x_RES is the response character.
const char ABORT_CMD				= 'a';
const char ACCELERATION_SHUTTER_CMD = 'E'; // Get/Set stepper acceleration
const char CALIBRATE_SHUTTER_CMD	= 'L'; // Calibrate the shutter
const char CLOSE_SHUTTER_CMD		= 'C'; // Close shutter
const char ELEVATION_SHUTTER_CMD	= 'G'; // Get/Set altitude
const char HELLO_CMD				= 'H'; // Let rotator know we're here
const char INACTIVE_SHUTTER_CMD		= 'X'; // Get/Set how long before shutter closes
const char OPEN_SHUTTER_CMD			= 'O'; // Open the shutter
const char POSITION_SHUTTER_GET		= 'P'; // Get step position
const char RAIN_INTERVAL_SET		= 'I'; // Tell us how long between checks in seconds
const char RAIN_SHUTTER_GET			= 'F'; // Rotator telling us if it's raining or not
const char SLEEP_SHUTTER_CMD		= 'S'; // Get/Set radio sleep settings
const char SPEED_SHUTTER_CMD		= 'R'; // Get/Set step rate (speed)
const char REVERSED_SHUTTER_CMD		= 'Y'; // Get/Set stepper reversed status
const char STATE_SHUTTER_GET		= 'M'; // Get shutter state
const char STEPSPER_SHUTTER_CMD		= 'T'; // Get/Set steps per stroke
const char VERSION_SHUTTER_GET		= 'V'; // Get version string
const char VOLTS_SHUTTER_CMD		= 'K'; // Get volts and get/set cutoff
const char WIRELESS_COMMENT			= 'B'; // Print comment over serial
#pragma endregion


ShutterClass Shutter = ShutterClass();
//XBeeClass XBee = XBeeClass();

bool SentHello = false, XbeeStarted = false;
bool isRaining = false;

unsigned long nextUpdateTime, nextStepTime;
unsigned long updateInterval, stepInterval;
unsigned long nextRainCheck;
bool doFinalUpdate = false;

void setup()
{
	Computer.begin(9600);
	Wireless.begin(9600);
	updateInterval = 1000;
	stepInterval = 100;
}

void loop()
{

	if (XbeeStarted == false)
	{
		DBPrintln("Wait for serial devices to start");
		Shutter.StartWirelessConfig();
		XbeeStarted = true;
	}
	if (SentHello == false && Shutter.isConfiguringWireless == false) SendHello();
	
	if (Computer.available() > 0) ReceiveComputer();

	if (Wireless.available()) ReceiveWireless();
	
	if (millis() > nextUpdateTime && (Shutter.sendUpdates == true || doFinalUpdate == true)) UpdateRotator();

	if (Shutter.isConfiguringWireless == false) RainCheck();

	Shutter.DoButtons();
	Shutter.Run();
}


///<SUMMARY>
///Send all data to rotator every second but stagger the messages over the second.
///</SUMMARY>
// Run through this once per second when the stepper is (or was) running. Shutter.sendUpdates is set to true
// in Shutter.run() if the motor is moving and set to false at the end of UpdateRotator.
// It's entirely possible for the motor to stop part way through the update steps which would mean the next time around
// no updates would be sent even though the data is different from what was already sent to the rotator. To prevent this
// the sendUpdates state is stored at the start of the update steps and checked at the end. If they are different then
// doFinalUpdate is set to true so the update cycle will run one final time even though the motor is stopped.

void UpdateRotator()
{
	static bool sentState, sentElevation, sentPosition, runningAtaStart;

	runningAtaStart = Shutter.sendUpdates; // Store motion state to comparison at end

	if (nextStepTime > millis()) return;

	if (sentState == false) 
	{
		Wireless.print(String(STATE_SHUTTER_GET) + String(Shutter.GetState()) + "#");
		sentState = true;
		nextStepTime = millis() + stepInterval;
		return;
	}

	//TODO: Not ready yet - when handbox is done finish this up
	if (sentElevation == false)
	{
		Wireless.print(String(ELEVATION_SHUTTER_CMD) + String(Shutter.GetElevation()) + "#");
		sentElevation = true;
		nextStepTime = millis() + stepInterval;
		return;
	}

	if (sentPosition == false)
	{
		Wireless.print(String(POSITION_SHUTTER_GET) + String(Shutter.GetPosition()) + "#");
		sentPosition = true;
		nextStepTime = millis() + stepInterval;
		return;
	}

	nextUpdateTime = millis() + updateInterval;

	sentState = sentElevation = sentPosition = false; // Reset the bools for the next cycle
	Shutter.sendUpdates = false;
	if (runningAtaStart != Shutter.sendUpdates) // See if motor stopped after update steps started
	{
		doFinalUpdate = true; // Motor stopped after starting the update steps so do one more update to catch those up.
	}
	else
	{
		doFinalUpdate = false;
	}
}
void SendHello()
{
	DBPrintln("Sending hello");
	Wireless.println("H#");
	SentHello = true;
}
void RainCheck()
{
	if (millis() > nextRainCheck)
	{
		DBPrintln("Asking for rain status");
		Wireless.print(String(RAIN_SHUTTER_GET) + "#");
		nextRainCheck = millis() + Shutter.rainCheckInterval;
	}
}
#pragma region Computer Communications
void ReceiveComputer()
{
	char character = Computer.read();

	if (character == '\r' || character == '\n')
	{
		// End of message
		if (computerBuffer.length() > 0)
		{
			ProcessComputer();
			computerBuffer = "";
		}
	}
	else
	{
		computerBuffer += String(character);
	}
}
void ProcessComputer()
{
	char command;
	String serialMessage, value;

	command = computerBuffer.charAt(0);
	value = computerBuffer.substring(1);
	value.trim();

	switch (command) // Uppercase is manual entry rather than rotator or ascom.
	{
	case ABORT_CMD:
		Shutter.Stop();
		DBPrintln(String(ABORT_CMD));
		break;
	case ELEVATION_SHUTTER_CMD:
		DBPrintln(String(Shutter.GetElevation()));
		break;
	case HELLO_CMD:
		SendHello();
		break;
	case STEPSPER_SHUTTER_CMD:
		Computer.println("T " + String((long)Shutter.GetStepsPerStroke()));
		break;
	case STATE_SHUTTER_GET:
		DBPrintln("M" + String(Shutter.GetState()));
		break;
	case SLEEP_SHUTTER_CMD:
//		XBee.CreateATString(value);
		break;
	// From manual entry
	default:
		break;
	}
}
#pragma endregion

#pragma region Wireless Communications
void ReceiveWireless()
{
	char character = Wireless.read();
	if (character == '\r' || character == '\n' || character == '#')
	{
		if (wirelessBuffer.length() > 0)
		{
			if (Shutter.isConfiguringWireless == true) 
			{
				Shutter.SetATString(wirelessBuffer);
			}
			else
			{
				ProcessWireless();
			}
			wirelessBuffer = "";
		}
	}
	else
	{
		wirelessBuffer += String(character);
	}
}
void ProcessWireless()
{
	float localFloat;
	int32_t local32;
	int16_t local16;

	String value, computerMessage="", wirelessMessage="";
	char command;

	
	command = wirelessBuffer.charAt(0); // If "H" the second letter says what it's from. We only care if it's "R", the rotator.
	value = wirelessBuffer.substring(1); // Payload if the command has data.
	//DBPrintln("Cmd:" + String(command) + " :" + value);
	switch (command)
	{
	case WIRELESS_COMMENT:
		DBPrintln("->DEBUG: " + String(command) + ":" + value);
		break;
	case ACCELERATION_SHUTTER_CMD:
		if (value.length() > 0) 
		{
			DBPrintln("Set acceleration to " + value);
			local32 = value.toInt();
			Shutter.SetAcceleration(local32);
		}
		wirelessMessage = String(ACCELERATION_SHUTTER_CMD) + String(Shutter.GetAcceleration());

		break;
	case ABORT_CMD:
		// Rotator update will be through UpdateRotator
		DBPrintln("STOP!");
		Shutter.Stop();
		break;
	case CALIBRATE_SHUTTER_CMD:
		DBPrintln("Calibrate");
		//todo: Add calibration routine and flag to stop all other commands except abort until it's finished.
		break;
	case CLOSE_SHUTTER_CMD:
		// Rotator update will be through UpdateRotator
		DBPrintln("Close shutter");
		if (Shutter.GetState() != Shutter.CLOSED) Shutter.Close();
		break;
	case ELEVATION_SHUTTER_CMD:
		// Rotator update will be through UpdateRotator
		// Send only error messages
		wirelessMessage = String(ELEVATION_SHUTTER_CMD);
		if (value.length() > 0)
		{
			DBPrint("Goto: " + value);
			localFloat = value.toFloat();
			if (isRaining == true)
			{
				wirelessMessage += "R";
			}
			else if (localFloat >= 0.0 && localFloat <= 90.0)
			{
				Shutter.GotoAltitude(localFloat);
			}
			else
			{
				wirelessMessage += "O"; // Outside bounds error. Should be taken care of by drive but manual input could be wrong.
			}
		}
		else
		{
			wirelessMessage += String(Shutter.GetElevation());
		}
		
		break;
	case HELLO_CMD:
		DBPrintln("Rotator says hello!");
		SendHello();
		DBPrint("Sent hello back");
		break;
	case OPEN_SHUTTER_CMD:
		DBPrintln("Open shutter");
		// Rotator update will be through UpdateRotator
		if (isRaining == false)
		{
			if (Shutter.GetState() != Shutter.OPEN) Shutter.Open();
		}
		else
		{
			DBPrintln("Can't, it's Raining!");
			wirelessMessage += "R";
		}
		break;
	case POSITION_SHUTTER_GET:
		 //Rotator update will be through UpdateRotator
		wirelessMessage = String(POSITION_SHUTTER_GET) + String(Shutter.GetPosition());
		break;
	case RAIN_INTERVAL_SET:
		if (value.length() > 0)
		{
			Shutter.rainCheckInterval = value.toInt();
			DBPrintln("Rain check interval set to " + value);
		}
		break;
	case RAIN_SHUTTER_GET:
		local16 = value.toInt();
		DBPrintln("Got rain status of " + value);
		if (local16 == 1)
		{
			if (isRaining == false)
			{
				Shutter.Close();
				isRaining = true;
				DBPrintln("It's raining! (" + value + ")");
			}
		}
		else
		{
			isRaining = false;
			DBPrintln("It's not raining");
		}
		break;
	case REVERSED_SHUTTER_CMD:
		if (value.length() > 0)
		{
			Shutter.SetReversed(value.equals("1"));
			DBPrintln("Set Reversed to " + value);
		}
		wirelessMessage = String(REVERSED_SHUTTER_CMD) + String(Shutter.GetReversed());
		break;
	case SPEED_SHUTTER_CMD:
		local32 = value.toInt();
		DBPrintln("Set speed to " + value);
		if (local32 > 0) Shutter.SetMaxSpeed(value.toInt());
		wirelessMessage = String(SPEED_SHUTTER_CMD) + String(Shutter.GetMaxSpeed());
		break;
	case STATE_SHUTTER_GET:
		wirelessMessage = String(STATE_SHUTTER_GET) + String(Shutter.GetState());
		break;
	case STEPSPER_SHUTTER_CMD:
		local32 = value.toInt();
		if (local32 > 0)
		{
			Shutter.SetStepsPerStroke(local32);
		}
		else 
		{
			DBPrintln("Get Steps " + String(Shutter.GetStepsPerStroke()));
		}
		wirelessMessage = String(STEPSPER_SHUTTER_CMD) + String(Shutter.GetStepsPerStroke());
		break;
	case VERSION_SHUTTER_GET:
		wirelessMessage = "V" + version;
		break;
	case VOLTS_SHUTTER_CMD:
		if (value.length() > 0)
		{
			Shutter.SetVoltsFromString(value);
			DBPrintln("Set volts to " + value);
		}
		wirelessMessage = "K" + Shutter.GetVoltString();
		break;
	default:
		DBPrintln("Unknown command " + String(command));
		break;
	}

	if (wirelessMessage.length() > 0)
	{
		Wireless.println(wirelessMessage +"#");
	}
}
#pragma endregion
