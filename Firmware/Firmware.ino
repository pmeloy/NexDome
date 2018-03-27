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

Rotator rotator;
const int HOME_PIN = 2;
const int VERSION_MAJOR = 0;
const int VERSION_MINOR = 1;
const int SERIALBUFFERLENGTH = 20;
char serialBuffer[SERIALBUFFERLENGTH];
long int localLong;
void setup()
{

	usb.begin(9600);
	wireless.begin(9600);
	rotator.loadConfig();

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
	if (usb.available())
	{
		incomingSerial(usb.read());
	}
	if (wireless.available())
	{
		char a;
		a = wireless.read();
		incomingWireless(a);
	}
}
void incomingSerial(char a)
{
	static int serialBufferPointer;

	if ((a == '\n') || (a == '\r')) {
		//  dont process an empty line feed
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
		//  we are going to overflow the buffer
		//  erase it and start over
		memset(serialBuffer, 0, SERIALBUFFERLENGTH);
		serialBufferPointer = 0;
	}
	else {
		serialBuffer[serialBufferPointer] = 0;
	}
	return;
}
void incomingWireless(char a)
{
	//Computer.print(a);
	//if ((a == '\n') || (a == '\r')) {
	//	return ProcessShutterData();
	//}
	////Computer.println((int)a);
	//WirelessBuffer[WirelessPointer] = a;
	//WirelessPointer++;
	//if (WirelessPointer == MY_SERIAL_BUFFER_SIZE) {
	//	memset(WirelessBuffer, 0, MY_SERIAL_BUFFER_SIZE);
	//	WirelessPointer = 0;
	//}
	//else {
	//	WirelessBuffer[WirelessPointer] = 0;
	//}
	//if (a < 0) {
	//	Computer.println("Wireless Clearing garbage");
	//	WirelessPointer = 0;
	//	WirelessBuffer[0] = 0;
	//}
	////Computer.print(a);
	//return;
}

void ProcessSerialCommand()
{
	float localFloat;
	char command;
	String value;
	int localInt, valueIndex = 1;
	String usbMessage = "";
	bool isStatus = false;
	long int localLong;
	command = serialBuffer[0];

	if (command == '%')
	{
		command = serialBuffer[1];
		valueIndex = 2;
		isStatus = true;
	}
	else
	{
		value = String(serialBuffer[1]);
	}

	switch (command) {
	case('*'):
		if (serialBuffer[valueIndex] == ' ')
		{
			localFloat = atof(&serialBuffer[valueIndex]);
			rotator.setAcceleration(localFloat);
		}
		usbMessage = "* " + String(rotator.getAcceleration());

		break;
	case ('?'):
		if (serialBuffer[valueIndex] == ' ')
		{
			localInt = atoi(&serialBuffer[valueIndex]);
			if (localInt == 1) rotator.setDefaults();
			usbMessage = "? 1";
		}
		else
		{
			rotator.loadConfig();
			usbMessage = "? 0";
		}
		break;
	case('/'):
		rotator.saveConfig();
		usbMessage = "/";
		break;
	case('('):
		usbMessage = "(" + String(rotator.getSeekMode());
		break;
	case ('$'):
		if (serialBuffer[valueIndex] == ' ')
		{
			localInt = atoi(&serialBuffer[valueIndex]);
			rotator.setStepMode(localInt);
		}
		usbMessage = "$ " + String(rotator.getStepMode());
		break;
	case ('['):
		if (serialBuffer[valueIndex] == ' ')
		{
			localLong = atol(&serialBuffer[valueIndex]);
			rotator.setSeekMode(HOMING_NONE);
			rotator.moveRelative(localLong);
		}
		usbMessage = "[ " + String(localLong);
		break;
	case ('#'):
		if (serialBuffer[valueIndex] == ' ')
		{
			localFloat = atof(&serialBuffer[valueIndex]);
			rotator.setMaxSpeed(localFloat);
		}
		usbMessage = "# " + String(rotator.getMaxSpeed());
		break;
	case('^'):
		usbMessage = "^ " + String(rotator.getDirection());
		break;
	case ('a'):
		// Abort move, stop at full step location
		usbMessage = "A";
		wireless.println("a");
		rotator.stop();
		break;
	case ('c'):
		rotator.startHoming(true);
		usbMessage = "C";
		break;
	case ('g'):
		localFloat = atof(&serialBuffer[valueIndex]);
		if ((localFloat >= 0.0) && (localFloat <= 360.0))
		{
			rotator.setAzimuth(localFloat);
			usbMessage = "G";
		}
		else
		{
			usbMessage = "E";
		}
		break;
	case ('h'):
		rotator.startHoming(false);
		usbMessage = "H";
		break;
	case ('i'):
		usbMessage = "I " + String(rotator.getHomeAzimuth());
		break;
	case ('j'):
		if ((serialBuffer[valueIndex] != 0x0a) && (serialBuffer[valueIndex] != 0x0d)) {
			localFloat = atof(&serialBuffer[valueIndex]);
			if ((localFloat >= 0) && (localFloat < 360)) rotator.setHomeAzimuth(localFloat);
		}
		usbMessage = "I " + String(rotator.getHomeAzimuth());
		break;
	case ('k'):
		if (serialBuffer[valueIndex] == ' ') {
			int newcutoff;
			newcutoff = atoi(&serialBuffer[valueIndex]);
			wireless.print("b ");
			wireless.println(newcutoff);
		}
		usbMessage = "K " + String(rotator.getControllerVoltage()) + " 0 " + String(rotator.getLowVoltageCutoff());
		break;
	case ('l'):
		localFloat = atof(&serialBuffer[valueIndex]);
		if ((localFloat >= 0) && (localFloat < 360))
		{
			rotator.setParkAzimuth(localFloat);
			usbMessage = "N " + String(rotator.getParkAzimuth());
		}
		else
		{
			usbMessage = "E";
		}
		break;
	case ('m'):
		usbMessage = "M " + String(rotator.isMoving());
		break;
	case ('n'):
		usbMessage = "N " + String(rotator.getParkAzimuth());
		break;
	case ('o'):
		usbMessage = "O 0.00";
		//rotatorStepperlastAzimuthError = rotatorStepperazimuthError;
		break;
	case ('p'):
		if (serialBuffer[valueIndex] == ' ')
		{
			localLong = atol(&serialBuffer[valueIndex]);
			if (localLong > 0 && localLong < rotator.getStepsPerRotation())
			{
				localLong = rotator.getPositionalDistance(rotator.getPosition(), localLong);
				rotator.moveRelative(localLong);
			}
			else
			{
				usbMessage = "E";
			}
		}
		else
		{
			usbMessage = "P " + String(rotator.getPosition());
		}
		break;
	case ('q'):
		usbMessage = "Q " + String(rotator.getAzimuth());
		break;
	case ('s'):
		localFloat = atof(&serialBuffer[valueIndex]);
		if (localFloat >= 0 && localFloat < 360)
		{
			rotator.syncHome(localFloat);
			rotator.syncPosition(localFloat);
			usbMessage = "S " + String(rotator.getAzimuth());
		}
		else
		{
			usbMessage = "E";
		}
		break;
	case ('t'):
		if (serialBuffer[valueIndex] == ' ') {
			localLong = atol(&serialBuffer[valueIndex]);
			rotator.setStepsPerRotation(localLong);
		}
		usbMessage = "T " + String(rotator.getStepsPerRotation());
		break;
	case ('v'):
		usbMessage = "VNexDome V " + String(VERSION_MAJOR) + "." + String(VERSION_MINOR);

		//if (rotatorSteppershutterVersion[0] != 0) 
		//{
		//	usb.print(" NexShutter V ");
		//	sendMessage =(rotatorSteppershutterVersion);
		//}

		break;
	case('x'):
		wireless.println("x");
		usbMessage = "X";
		break;
	case ('y'):
		if (serialBuffer[valueIndex] == ' ')
		{
			bool flag = false;
			localInt = atoi(&serialBuffer[valueIndex]);
			if (localInt == 1) flag = true;
			rotator.setReversed(flag);
		}
		usbMessage = "Y " + String(rotator.getReversed());
		break;
	case ('z'):
		usbMessage = "Z " + String(rotator.getHomeStatus());
		break;
		//
		// Wireless or accessories which I don't have
		//
	case ('b'):
		usbMessage = "B 0";
		break;
	case ('d'):
		// If not raining, open shutter
		if (rotator.isRaining() == true)
		{
			usbMessage = "E";
		}
		else
		{
			usbMessage = "D";
			wireless.println("D");
			//if (rotatorSteppershutterState != SHUTTER_STATE_NOT_CONNECTED) rotatorSteppershutterState = SHUTTER_STATE_OPENING;
		}
		break;
	case ('e'):
		// Close shutter
		usbMessage = "D";
		wireless.println("c");
		//if (rotatorSteppershutterState != SHUTTER_STATE_NOT_CONNECTED) rotatorSteppershutterState = SHUTTER_STATE_CLOSING;
		break;
	case ('f'):
		// Set shutter position
		usbMessage = "F";
		localFloat = atof(&serialBuffer[valueIndex]);
		wireless.print("f ");
		wireless.print(localFloat);
		break;
	case ('r'):
		// Set shutter hibernate timer
		if (serialBuffer[valueIndex] == ' ')
		{
			unsigned long int newtimer;
			newtimer = atol(&serialBuffer[valueIndex]);
			wireless.print("h ");
			wireless.println(newtimer);
			// shutter.shutterHibernateTimer = newtimer;
		}
		usbMessage = "R 0";
		break;
	case('u'):
		usbMessage = "U 0";// " + String(rotator.isRaining());
		break;
	case ('w'):
		usbMessage = "W";
		// configureWireless();
		break;
	}

	if (usbMessage != "")
	{
		//if (isStatus == true) usb.print("%");
		usb.println(usbMessage);
	}


}



