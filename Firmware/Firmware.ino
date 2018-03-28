#include "RotatorClass.h"
#include <AccelStepper.h>

/*
% - flags command as status request that adds a percent sign to the response. Used by Configurator only
[ - Direct call to moveRelative (give positive or negative long int for how many steps and in what direction.
# - Get max speed or supply a float and set it
^ - Get the current direction of rotation -1 CCWm 1 CW, 0 none
$ - Get/Set stepping mode 1, 2, 4, 8, or 16 microsteps INT
* - Get/Set Acceleration FLOAT
| - Get/Set Home center. Half of the width of home switch magnetic field as a stopping point for home operation.
\ - Get seek mode
C - Just a comment
? - Load Config from EEPROM or set to defaults if 1
/ - Save Config to EEPROM
W 1 - Wipe EEPROM (needs the 1 or it aborts)
*/

#pragma region "Declarations and Variables"
Rotator rotator;
//Shutter shutter;
const int HOME_PIN = 2;
const int VERSION_MAJOR = 0;
const int VERSION_MINOR = 1;
long int localLong;
#pragma endregion

#pragma region "Serial Declarations and Variables"
#define serialPort Serial
const int SERIALBUFFERLENGTH = 20;
char serialBuffer[SERIALBUFFERLENGTH];
int serialBufferPointer = 0;
#pragma endregion

#pragma region "wirelessPort Declarations and Variables"
#define wirelessPort Serial1

const int SHUTTER_INTERRUPT_PIN = 3;
const int SHUTTER_STATE_NOT_CONNECTED = 0;
const int SHUTTER_STATE_OPEN = 1;
const int SHUTTER_STATE_OPENING = 2;
const int SHUTTER_STATE_CLOSED = 3;
const int SHUTTER_STATE_CLOSING = 4;
const int SHUTTER_STATE_UNKNOWN = 5;
const int SHUTTER_VERSION_LENGTH = 5;

char wirelessBuffer[SERIALBUFFERLENGTH];
int wirelessBufferPointer = 0;
bool foundShutter = false;
unsigned long int LastShutterResponse = 0;
unsigned long int LastShutterKeepAlive = 0;
//  The shutter sleep period ss 15 seconds
//  Lets query it on every second sleep cycle
//  but send one second early to ensure we catch it
//  when it wakes up
#define SHUTTER_SLEEP_WAIT 29000
//  When in alive mode, the timing for each cycle is one second
//  Query slightly early so the query is waiting when it wakes up
#define SHUTTER_AWAKE_WAIT 900
int ShutterState = SHUTTER_STATE_NOT_CONNECTED;
float ShutterPosition = 0;
unsigned int ShutterQueryTime;
char ShutterVersion[SHUTTER_VERSION_LENGTH];
unsigned long int ShutterHibernateTimer = 0;
int ShutterBatteryVolts = 0;
int LowVoltCutoff = 0;
bool doingWirelessConfig = false;
int wirelessConfigState = 0;
bool ShutterAlive = false;

#pragma endregion

#pragma region "Arduino Setup and Loop"
void setup()
{
	serialPort.begin(9600);
	wirelessPort.begin(9600);
	rotator.loadConfig();
	pinMode(SHUTTER_INTERRUPT_PIN, INPUT_PULLUP);
	ShutterQueryTime = SHUTTER_SLEEP_WAIT;
	ConfigurewirelessPort();
}
void loop()
{
	rotator.run();
	checkForCommands();
	//if (rotator.getSeekMode() != 0) rotator.doHomeOrCalibrate();
	String test = "123";
}
void checkForCommands()
{
	if (serialPort.available())
	{
		incomingSerial(serialPort.read());
	}
	if (wirelessPort.available())
	{
		char a;
		a = wirelessPort.read();
		incomingWirelessChar(a);
	}
}
#pragma endregion

#pragma region "Serial handling";

void incomingSerial(char a)
{
	if ((a == '\n') || (a == '\r')) {
		if (serialBufferPointer > 0) {
			ProcessSerialCommand();
		}
		memset(serialBuffer, 0, SERIALBUFFERLENGTH);
		serialBufferPointer = 0;
		return;
	}

	serialBuffer[serialBufferPointer] = a;
	serialBufferPointer++;
	if (serialBufferPointer == SERIALBUFFERLENGTH) {
		memset(serialBuffer, 0, SERIALBUFFERLENGTH);
		serialBufferPointer = 0;
	}
	else 
	{
		serialBuffer[serialBufferPointer] = 0;
	}
	return;
}
void ProcessSerialCommand()
{
	float localFloat;
	char command;
	String value;
	int localInt, valueIndex = 1;
	String serialMessage = "";
	bool isStatus = false;
	long int localLong;
	command = serialBuffer[0];
	value = String(serialBuffer);
	value = value.substring(1);
	value.trim();

	switch (command) {
	case('*'):

		if (value.length() > 0)
		{
			localFloat = value.toFloat();
			rotator.setAcceleration(value.toFloat());
		}
		serialMessage = "* " + String(rotator.getAcceleration());
		break;
	case ('?'):
		if (value.toInt() == 1)
		{
			rotator.setDefaults();
			serialMessage = "? 1";
		}
		else
		{
			rotator.loadConfig();
			serialMessage = "? 0";
		}
		break;
	case('/'):
		rotator.saveConfig();
		serialMessage = "/";
		break;
	case('('):
		serialMessage = "( " + String(rotator.getSeekMode());
		break;
	case ('$'):
		localInt = value.toInt();
		if (localInt > 0)	rotator.setStepMode(localInt);
		serialMessage = "$ " + String(rotator.getStepMode());
		break;
	case ('['):
		if (value.length() > 0)
		{
			localLong = value.toInt();
			rotator.setSeekMode(HOMING_NONE);
			rotator.moveRelative(localLong);
			serialMessage = "[ " + String(localLong);
		}
		else
		{
			serialMessage = "E";
		}
		break;
	case ('#'):
		localFloat = value.toFloat();
		if (localFloat > 0)	rotator.setMaxSpeed(localFloat);
		serialMessage = "# " + String(rotator.getMaxSpeed());
		break;
	case('^'):
		serialMessage = "^ " + String(rotator.getDirection());
		break;
	case ('a'):
		serialMessage = "A";
		wirelessPort.println("a");
		rotator.stop();
		break;
	case ('c'):
		rotator.startHoming(true);
		serialMessage = "C";
		break;
	case ('g'):
		if (value.length() > 0)
		{
			localFloat = value.toFloat();
			if ((localFloat >= 0.0) && (localFloat <= 360.0))
			{
				rotator.setAzimuth(localFloat);
				serialMessage = "G";
			}
			else
			{
				serialMessage = "E";
			}
		}
		break;
	case ('h'):
		rotator.startHoming(false);
		serialMessage = "H";
		break;
	case ('i'):
		serialMessage = "I " + String(rotator.getHomeAzimuth());
		break;
	case ('j'):
		if (value.length() > 0)
		{
			localFloat = value.toFloat();
			if ((localFloat >= 0) && (localFloat < 360)) rotator.setHomeAzimuth(localFloat);
		}
		serialMessage = "I " + String(rotator.getHomeAzimuth());
		break;
	case ('k'):
		//todo: Implement this
		// Set cuttoff voltage for shutter
		localInt = value.toInt();
		if (localInt > 0) {
			wirelessPort.print("b ");
			wirelessPort.println(localInt);
		}
		serialMessage = "K " + String(rotator.getControllerVoltage()) + " " + String(ShutterBatteryVolts)+ " " + String(rotator.getLowVoltageCutoff());
		break;
	case ('l'):
		// Set Park Azumith
		if (value.length() > 0)
		{
			localFloat = value.toFloat();
			if ((localFloat >= 0) && (localFloat < 360))
			{
				rotator.setParkAzimuth(localFloat);
				serialMessage = "N " + String(rotator.getParkAzimuth());
			}
			else
			{
				serialMessage = "E";
			}
		}
		else
		{
			serialMessage = "E";
		}
		break;
	case ('m'):
		serialMessage = "M " + String(rotator.isMoving());
		break;
	case ('n'):
		serialMessage = "N " + String(rotator.getParkAzimuth());
		break;
	case ('o'):
		//todo: Implement azimuth error
		serialMessage = "O 0.00";
		//rotatorStepperlastAzimuthError = rotatorStepperazimuthError;
		break;
	case ('p'):
		if (value.length() > 0)
		{
			localLong = value.toInt();
			if (localLong > 0 && localLong < rotator.getStepsPerRotation())
			{
				localLong = rotator.getPositionalDistance(rotator.getPosition(), localLong);
				rotator.moveRelative(localLong);
			}
			else
			{
				serialMessage = "E";
			}
		}
		else
		{
			serialMessage = "P " + String(rotator.getPosition());
		}
		break;
	case ('q'):
		serialMessage = "Q " + String(rotator.getAzimuth());
		break;
	case ('s'):
		localFloat = value.toFloat();
		if (localFloat >= 0 && localFloat < 360)
		{
			rotator.syncHome(localFloat);
			rotator.syncPosition(localFloat);
			serialMessage = "S " + String(rotator.getAzimuth());
		}
		else
		{
			serialMessage = "E";
		}
		break;
	case ('t'):
		localLong = value.toInt();
		if (localLong > 0) rotator.setStepsPerRotation(localLong);
		serialMessage = "T " + String(rotator.getStepsPerRotation());
		break;
	case ('v'):
		serialMessage = "VNexDome V " + String(VERSION_MAJOR) + "." + String(VERSION_MINOR);

		if (ShutterVersion[0] != 0) 
		{
			serialMessage +=" NexShutter V " + String(ShutterVersion);
		}
		break;
	case('x'):
		wirelessPort.println("x");
		serialMessage = "X";
		break;
	case ('y'):
		if (value.length() > 0)
		{
			bool flag = (value.toInt() == 1);
			rotator.setReversed(flag);
		}
		serialMessage = "Y " + String(rotator.getReversed());
		break;
	case ('z'):
		serialMessage = "Z " + String(rotator.getHomeStatus());
		break;
		//
		// wirelessPort or accessories which I don't have
		//
	case ('b'):
		serialMessage = "B " + String(ShutterPosition);
		break;
	case ('d'):
		// If not raining, open shutter
		if (rotator.isRaining() == true)
		{
			serialMessage = "E";
		}
		else
		{
			serialMessage = "D";
			wirelessPort.println("o");
			if (ShutterState != SHUTTER_STATE_NOT_CONNECTED) ShutterState = SHUTTER_STATE_OPENING;
		}
		break;
	case ('e'):
		// Close shutter
		serialMessage = "D";
		wirelessPort.println("c");
		if (ShutterState != SHUTTER_STATE_NOT_CONNECTED) ShutterState = SHUTTER_STATE_CLOSING;
		break;
	case ('f'):
		// Set shutter position
		if (value.length() > 0)
		{
			serialMessage = "F";
			localFloat = value.toFloat();
			wirelessPort.print("f ");
			wirelessPort.println(localFloat);
		}
		break;
	case ('r'):
		// Set shutter hibernate timer
		localLong = value.toInt();
		if (localLong > 0)
		{
			wirelessPort.print("h ");
			wirelessPort.println(localLong);
			// shutter.shutterHibernateTimer = newtimer;
		}
		serialMessage = "R " + String(ShutterHibernateTimer);
		break;
	case('u'):
		serialMessage = "U " + String(ShutterState);// " + String(rotator.isRaining());
		break;
	case ('w'):
		serialMessage = "W";
		ConfigurewirelessPort();
		break;
	}

	if (serialMessage != "")
	{
		serialPort.println(serialMessage);
	}
}

#pragma endregion

#pragma region "wirelessPort Handling"
void ConfigurewirelessPort()
{
	//  do nothing for now
	//return;
	//serialPort.println("Sending + to xbee");
	delay(1100);
	doingWirelessConfig = true;
	wirelessConfigState = 0;
	memset(wirelessBuffer, 0, SERIALBUFFERLENGTH);
	wirelessBufferPointer = 0;
	wirelessPort.print("+++");
}
void incomingWirelessChar(char a)
{
	if ((a == '\n') || (a == '\r')) {
		return ProcessShutterResponse();
	}
	wirelessBuffer[wirelessBufferPointer] = a;
	wirelessBufferPointer++;
	if (wirelessBufferPointer == SERIALBUFFERLENGTH) {
		memset(wirelessBuffer, 0, SERIALBUFFERLENGTH);
		wirelessBufferPointer = 0;
	}
	else {
		wirelessBuffer[wirelessBufferPointer] = 0;
	}
	if (a < 0) {
		serialPort.println("wirelessPort Clearing garbage");
		wirelessBufferPointer = 0;
		wirelessBuffer[0] = 0;
	}
	return;
}
void ProcessShutterResponse()
{
	//serialPort.println("Wireless Response: " + String(wirelessBuffer));
	if (wirelessBuffer[0] == 'O') 
	{
		if (wirelessBuffer[1] == 'K') 
		{
			//  The xbee unit is ready for configuration
			foundShutter = true;
			if (doingWirelessConfig) 
			{
				//serialPort.println("ConfigState = " + String(wirelessConfigState));
				switch (wirelessConfigState) 
				{
				case 0:
					//  We could do the whole setup in just one command
					//  but it gives back the same number of OK responses
					//  So we have to parse out every OK anyways, may as well just
					//  do one setting per OK return
					//wirelessPort.println("ATID5555,CE1,PL0,SM4,SP5DC,ST100,CN");
					wirelessPort.println("ATID5555");
					//serialPort.println("Setting wirelessPort id");
					break;

				case 1:
					wirelessPort.println("ATCE1");
					//serialPort.println("Setting cordinator");
					break;

				case 2:
					wirelessPort.println("ATPL0");
					//serialPort.println("Setting Power");
					break;

				case 3:
					wirelessPort.println("ATSM4");
					//wirelessPort.println("ATSM0");
					//serialPort.println("Setting sleep mode");
					break;

				case 4:
					//  set sleep period, this is the co-ordinator
					//  so it defines how long we will hold a message
					//  for the endpoint
					wirelessPort.println("ATSP5DC");
					//serialPort.println("Setting sleep period");
					break;

				case 5:
					wirelessPort.println("ATST100");
					//serialPort.println("Setting sleep wait time");
					break;

				case 6:
					wirelessPort.println("ATCN");
					//serialPort.println("Exit command mode");
					break;

				default:
					//  Finished configuring, now see if the shutter is alive
					wirelessPort.println("s");
					//serialPort.println("wirelessPort config finished");
					doingWirelessConfig = false;
					break;
				}
				wirelessConfigState++;
			}
			//serialPort.println("Clear wirelessPort buffer");
			memset(wirelessBuffer, 0, SERIALBUFFERLENGTH);
			wirelessBufferPointer = 0;
			return;
		}
	}
	// update our timer for the keep alive routines
	if (!ShutterAlive) 
	{
		//serialPort.println("Shutter is asleep!");
		if (wirelessBuffer[0] == 'S') 
		{
			serialPort.println(wirelessBuffer);
			serialPort.println("Shutter woke up");
			ShutterAlive = true;
		}
	}
	if (ShutterAlive) {
		if (wirelessBuffer[0] == 'S') 
		{
			long int newShutterState;
			LastShutterResponse = millis();
			LastShutterKeepAlive = millis();  //  mark this time for our keepalive routines as well
											  //  the first character in the response is the shutter state
											  //ShutterQueryTime=SHUTTER_SLEEP_WAIT;
			if (wirelessBuffer[2] == '0')
			{
				ShutterQueryTime = SHUTTER_AWAKE_WAIT;
			}
			else 
			{
				ShutterQueryTime = SHUTTER_SLEEP_WAIT;
			}
			switch (wirelessBuffer[1]) 
			{
			case 'C':
				newShutterState = SHUTTER_STATE_CLOSED;
				break;
			case 'O':
				newShutterState = SHUTTER_STATE_OPEN;
				break;
			case 'P':
				newShutterState = SHUTTER_STATE_OPENING;
				ShutterQueryTime = SHUTTER_AWAKE_WAIT;
				break;
			case 'D':
				newShutterState = SHUTTER_STATE_CLOSING;
				ShutterQueryTime = SHUTTER_AWAKE_WAIT;
				break;
			default:
				newShutterState = SHUTTER_STATE_UNKNOWN;
				break;
				//default:
				//  ShutterState=SHUTTER_STATE_NOT_CONNECTED;
				//  break;
			}
			if (newShutterState != ShutterState) 
			{
				ShutterState = newShutterState;
				serialPort.print("Shutter State ");
				serialPort.println(ShutterState);
			}
			// shutter has responded with a status
			// lets ask it for a position
			if ((ShutterState != SHUTTER_STATE_OPENING) && (ShutterState != SHUTTER_STATE_CLOSING))wirelessPort.println("p");
		}
		if (wirelessBuffer[0] == 'P') 
		{
			ShutterPosition = atof(&wirelessBuffer[1]);
			//serialPort.println("Shutter Position ");
			//serialPort.println(q);
			//  We got a position
			//  lets ask for battery voltage
			wirelessPort.println("b");
		}
		if (wirelessBuffer[0] == 'B') 
		{
			char *ptr;
			ShutterBatteryVolts = atoi(&wirelessBuffer[1]);
			//  now find the low voltage cutoff if it exists
			ptr = &wirelessBuffer[2];
			while ((ptr[0] != 0) && (ptr[0] != ' ') && (ptr[0] != 0x0a) && (ptr[0] != 0x0d)) ptr++;
			if (ptr[0] == ' ') 
			{
				LowVoltCutoff = atoi(&ptr[0]);
			}
			if (ShutterHibernateTimer == 0) 
			{
				wirelessPort.println("h");
			}
			if (ShutterVersion[0] == 0) 
			{
				//  if we dont have a version for the shutter
				//  fetch it now
				//serialPort.println("Fetch Shutter Version");
				wirelessPort.println("v");
			}
		}
		if (wirelessBuffer[0] == 'V') 
		{
			//serialPort.print("Shutter Version ");
			//serialPort.println(wirelessBuffer);
			memcpy(ShutterVersion, &wirelessBuffer[12], 4);
			//serialPort.println(ShutterVersion);
		}
		if (wirelessBuffer[0] == 'H') 
		{
			if (wirelessBuffer[1] == ' ') 
			{
				ShutterHibernateTimer = atol(&wirelessBuffer[1]);
			}
		}
	}

	// clear the buffer now that it's processed
	memset(wirelessBuffer, 0, SERIALBUFFERLENGTH);
	wirelessBufferPointer = 0;

	return;

}

#pragma endregion



