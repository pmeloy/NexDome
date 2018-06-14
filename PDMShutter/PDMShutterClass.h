/*
* PDM NexDome Shutter kit firmware. NOT compatible with original NexDome ASCOM driver or Rotation kit firmware.
*
* Copyright © 2018 Patrick Meloy
* Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
*  files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy,
*  modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software
*  is furnished to do so, subject to the following conditions:
*  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*
*  THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
*  OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
*  BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF
*  OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*
*  Inspired by the original official NexDome firmware by grozzie2 but completely incompatible.
*  https://github.com/grozzie2/NexDome
*/

#pragma once

#pragma region Includes
#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif
#pragma endregion


#define Computer Serial
#define Wireless Serial1

#pragma region Debug Printing
// Debug printing, uncomment #define DEBUG to enable
//#define DEBUG
#ifdef DEBUG
#define DBPrint(x) Serial.print(x)
#define DBPrintln(x) Serial.println(x)
#else
#define DBPrint(x)
#define DBPrintln(x)
#endif // DEBUG
#pragma endregion

#pragma region AccelStepper Setup
const uint8_t	STEPPER_ENABLE_PIN = 10;
const uint8_t	STEPPER_DIRECTION_PIN = 11;
const uint8_t	STEPPER_STEP_PIN = 12;

const int	CLOSED_PIN = 2;
const int	OPENED_PIN = 3;
const uint8_t	BUTTON_OPEN = 5;
const uint8_t	BUTTON_CLOSE = 6;
const uint8_t	ESTOP_PIN = 14;

AccelStepper stepper(AccelStepper::DRIVER, STEPPER_STEP_PIN, STEPPER_DIRECTION_PIN);
#pragma endregion

#pragma region Shutter Header
class ShutterClass
{
public:
	// Constructor
	ShutterClass();

	enum ShutterStates { OPEN, CLOSED, OPENING, CLOSING, ERROR };

	bool		present = false;

	bool		wasRunning = false;
	bool		sendUpdates = false;

	bool		isConfiguringWireless = false;

	long int	rainCheckInterval;

	// Helper functions
	float		PositionToAltitude(long);
	long		AltitudeToPosition(float);

	// Wireless functions
	void		StartWirelessConfig();
	void		ChangeSleepSettings(String);
	void		ConfigXBee(String);

	// Getters
	int32_t		GetAcceleration();
	float		GetElevation();
	int			GetEndSwitchStatus();
	uint32_t	GetMaxSpeed();
	long		GetPosition();
	bool		GetReversed();
	short		GetState();
	uint32_t	GetStepsPerStroke();
	bool		GetVoltsAreLow();
	String		GetVoltString();

	// Setters
	void		SetAcceleration(uint16_t);
	void		SetMaxSpeed(uint16_t);
	void		SetReversed(bool);
	void		SetStepsPerStroke(uint32_t);
	void		SetVoltsFromString(String);

	// Movers
	void		DoButtons();
	void		Open();
	void		Close();
	void		GotoPosition(long);
	void		GotoAltitude(float);
	void		MoveRelative(long);

	void		Run();
	void		Stop();


private:

	typedef struct Configuration
	{
		int			signature;
		byte		sleepMode;
		uint16_t	sleepPeriod;
		uint16_t	sleepDelay;
		uint64_t	stepsPerStroke;
		uint16_t	acceleration;
		uint16_t	maxSpeed;
		uint8_t		stepMode;
		uint8_t		reversed;
		uint16_t	cutoffVolts;
		long int	rainCheckInterval;
		uint16_t	jogStart; // milliseconds before triggering "sticky" move
		uint16_t	jogMax; // milliseconds after which "sticky" expires
		bool		eStopEnabled;
	};

	const int		_eepromLocation = 100;
	const int		_eePromSignature = 4752;

	byte			_sleepMode = 0;
	uint16_t		_sleepPeriod = 300;
	uint16_t		_sleepDelay = 30000;
	String			_ATString;
	int				_configStep;

	bool			_hasClosed = false;
	uint16_t		_acceleration;
	uint16_t		_maxSpeed;
	bool			_reversed;
	uint8_t			_closedPin;
	uint8_t			_openedPin;
	uint8_t			_enablePin;
	uint8_t			_eStopPin;
	bool			_eStopEnabled;

	uint16_t		_volts;
	uint64_t		_batteryCheckInterval = 120000;
	uint16_t		_cutoffVolts = 1220;

	uint16_t		_jogStart;
	uint16_t		_jogMax;

	uint8_t			_lastButtonPressed;

	ShutterStates	_shutterState = ERROR;
	uint64_t		_stepsPerStroke;
	uint8_t			_stepMode;


	float		MeasureVoltage();
	void		ReadEEProm();
	void		WriteEEProm();
	void		DefaultEEProm();
};

#pragma endregion$

#pragma region Shutter CPP

#define VOLTAGE_MONITOR_PIN A0

ShutterClass::ShutterClass()
{
	ReadEEProm();
	_openedPin = OPENED_PIN;
	_closedPin = CLOSED_PIN;
	_eStopPin = ESTOP_PIN;

	pinMode(CLOSED_PIN, INPUT_PULLUP);
	pinMode(OPENED_PIN, INPUT_PULLUP);
	pinMode(STEPPER_STEP_PIN, OUTPUT);
	pinMode(STEPPER_DIRECTION_PIN, OUTPUT);
	pinMode(STEPPER_ENABLE_PIN, OUTPUT);
	pinMode(BUTTON_OPEN, INPUT_PULLUP);
	pinMode(BUTTON_CLOSE, INPUT_PULLUP);
	pinMode(ESTOP_PIN, INPUT);

	pinMode(VOLTAGE_MONITOR_PIN, INPUT);

	ReadEEProm();
	SetAcceleration(_acceleration);
	SetMaxSpeed(_maxSpeed);

}

// EEPROM
void		ShutterClass::DefaultEEProm()
{
	_sleepMode = 0;
	_sleepPeriod = 300;
	_sleepDelay = 30000;
	_stepsPerStroke = 885000;
	_acceleration = 7000;
	_maxSpeed = 5000;
	_stepMode = 8;
	_reversed = false;
	_cutoffVolts = 1220;
	rainCheckInterval = 30000;
	_eStopEnabled = false;
	_jogStart = 1000;
	_jogMax = 3000;
}
void		ShutterClass::ReadEEProm()
{
	Configuration cfg;
	//memset(&cfg, 0, sizeof(cfg));
	EEPROM.get(_eepromLocation, cfg);
	if (cfg.signature != _eePromSignature)
	{
		DBPrintln("Shutter invalid sig, defaults " + String(cfg.signature) + " = " + String(_eePromSignature));
		DefaultEEProm();
		WriteEEProm();
		return;
	}
	DBPrintln("Shutter good sig");
	_sleepMode		= cfg.sleepMode;
	_sleepPeriod	= cfg.sleepPeriod;
	_sleepDelay		= cfg.sleepDelay;
	_stepsPerStroke = cfg.stepsPerStroke;
	_acceleration	= cfg.acceleration;
	_maxSpeed		= cfg.maxSpeed;
	_stepMode		= cfg.stepMode;
	_cutoffVolts	= cfg.cutoffVolts;
	rainCheckInterval = cfg.rainCheckInterval;
	_eStopEnabled	= cfg.eStopEnabled;
	_jogStart		= cfg.jogStart;
	_jogMax			= cfg.jogMax;
}
void		ShutterClass::WriteEEProm()
{
	Configuration cfg;
	//memset(&cfg, 0, sizeof(cfg));
	DBPrintln("Signature is " + String(_eePromSignature));
	cfg.signature		= _eePromSignature;
	cfg.sleepMode		= _sleepMode;
	cfg.sleepPeriod		= _sleepPeriod;
	cfg.sleepDelay		= _sleepDelay;
	cfg.stepsPerStroke	= _stepsPerStroke;
	cfg.acceleration	= _acceleration;
	cfg.maxSpeed		= _maxSpeed;
	cfg.stepMode		= _stepMode;
	cfg.cutoffVolts		= _cutoffVolts;
	cfg.rainCheckInterval = rainCheckInterval;
	cfg.eStopEnabled	= _eStopEnabled;
	cfg.jogStart		= _jogStart;
	cfg.jogMax			= _jogMax;

	EEPROM.put(_eepromLocation, cfg);
	DBPrintln("Wrote sig of " + String(cfg.signature));
}

// INPUTS
void		ShutterClass::DoButtons()
{
	int PRESSED = 0;
	static int whichButtonPressed = 0, lastButtonPressed = 0;

	if (digitalRead(BUTTON_OPEN) == PRESSED && whichButtonPressed == 0 && GetEndSwitchStatus() != OPEN)
	{
		DBPrintln("Button Open Shutter");
		whichButtonPressed = BUTTON_OPEN;
		_shutterState = OPENING;
		MoveRelative(_stepsPerStroke);
		lastButtonPressed = BUTTON_OPEN;
	}
	else if (digitalRead(BUTTON_CLOSE) == PRESSED && whichButtonPressed == 0 && GetEndSwitchStatus() != CLOSED)
	{
		DBPrintln("Button Close Shutter");
		whichButtonPressed = BUTTON_CLOSE;
		_shutterState = CLOSING;
		MoveRelative(1 - _stepsPerStroke);
		lastButtonPressed = BUTTON_CLOSE;
	}

	if (digitalRead(whichButtonPressed) == !PRESSED && lastButtonPressed > 0)
	{
		Stop();
		lastButtonPressed = whichButtonPressed = 0;
	}
}
float		ShutterClass::MeasureVoltage()
{
	int volts;

	volts = analogRead(VOLTAGE_MONITOR_PIN);
	volts = volts / 2;
	volts = volts * 3;
	DBPrintln("Voltage is " + String(volts));
	_volts = volts;
	return volts;
}

// Helper functions
long		ShutterClass::AltitudeToPosition(float alt)
{
	long result;

	result = (long)(_stepsPerStroke * alt / 90.0);
	return result;
}
float		ShutterClass::PositionToAltitude(long pos)
{
	float result = (float)pos;
	result = result / _stepsPerStroke * 90.0;
	return result;
}

// Wireless Functions
void		ShutterClass::StartWirelessConfig()
{
	delay(1000);
	DBPrintln("Sending +++");
	isConfiguringWireless = true;
	Wireless.print("+++");
	delay(1000);
}
inline void ShutterClass::ChangeSleepSettings(String values)
{
	int start, index;
	uint16_t temp;
	DBPrintln("Was sent " + values);

	index = values.indexOf(',');
	_sleepMode = values.substring(0, index).toInt();

	start = index + 1;
	index = values.indexOf(',', index + 1);
	_sleepPeriod = values.substring(start, index).toInt();

	start = index + 1;
	_sleepDelay = values.substring(start).toInt();
	DBPrintln("Vars set to " + String(_sleepMode) + "," + String(_sleepPeriod) + "," + String(_sleepDelay));
	WriteEEProm();
	ReadEEProm();
}
inline void ShutterClass::ConfigXBee(String result)
{
	if (_configStep == 0)
	{
		_ATString = "ATCE0,ID7734,AP0";
		_ATString += ",SM" + String(_sleepMode, HEX);
		_ATString += ",SP" + String(_sleepPeriod, HEX);
		_ATString += ",ST" + String(_sleepDelay, HEX);
		_ATString += ",CN";
		_ATString.toUpperCase();
		DBPrintln("AT String " + _ATString);
		Wireless.println(_ATString);
	}
	_configStep++;

	if (_configStep < 8)
	{
		DBPrintln("Arg " + String(_configStep) + ": " + result);
	}
	else
	{
		DBPrintln("Wireless Configured");
		isConfiguringWireless = false;
	}
}

// Getters
int32_t		ShutterClass::GetAcceleration()
{
	return _acceleration;
}
int			ShutterClass::GetEndSwitchStatus()
{
	int result= ERROR;
	if (digitalRead(CLOSED_PIN) == 0) result = CLOSED;
	if (digitalRead(OPENED_PIN) == 0) result = OPEN;
	return result;
}
float		ShutterClass::GetElevation()
{
	return PositionToAltitude(stepper.currentPosition());
}
uint32_t	ShutterClass::GetMaxSpeed()
{
	return stepper.maxSpeed();
}
long		ShutterClass::GetPosition()
{
	return stepper.currentPosition();
}
bool		ShutterClass::GetReversed()
{
	return _reversed;
}
short		ShutterClass::GetState()
{
	return (short)_shutterState;
}
uint32_t	ShutterClass::GetStepsPerStroke()
{
	return _stepsPerStroke;
}
inline bool ShutterClass::GetVoltsAreLow()
{
	bool low = (_volts <= _cutoffVolts);
	return low;
}
String		ShutterClass::GetVoltString()
{
	return String(_volts) + "," + String(_cutoffVolts);
}

// Setters
void		ShutterClass::SetAcceleration(uint16_t accel)
{
	_acceleration = accel;
	stepper.setAcceleration(accel);
}
void		ShutterClass::SetMaxSpeed(uint16_t speed)
{
	stepper.setMaxSpeed(speed);
}
void		ShutterClass::SetReversed(bool reversed)
{
	_reversed = reversed;
	stepper.setPinsInverted(reversed, reversed, reversed);
	WriteEEProm();
}
void		ShutterClass::SetStepsPerStroke(uint32_t newSteps)
{
	_stepsPerStroke = newSteps;
}
void		ShutterClass::SetVoltsFromString(String value)
{
	_cutoffVolts = value.toInt();
	WriteEEProm();
}

// Movers
void		ShutterClass::Open()
{
	_shutterState = OPENING;
	MoveRelative(_stepsPerStroke * 1.2);
}
void		ShutterClass::Close()
{
	_shutterState = CLOSING;
	MoveRelative(1 - _stepsPerStroke * 1.2);
}
void		ShutterClass::GotoPosition(long newPos)
{
	uint64_t currentPos = stepper.currentPosition();
	bool doMove = false;

	// Check if this actually changes position, then move if necessary.
	if (newPos > currentPos)
	{
		_shutterState = OPENING;
		doMove = true;
	}
	else if (newPos < currentPos)
	{
		_shutterState = CLOSING;
		doMove = true;
	}
	if (doMove == true) stepper.moveTo(newPos);
}
void		ShutterClass::GotoAltitude(float newAlt)
{

	GotoPosition(AltitudeToPosition(newAlt));
}
void		ShutterClass::MoveRelative(long amount)
{
	stepper.move(amount);
}
void		ShutterClass::Run()
{
	static uint64_t nextBatteryCheck;
	static bool hitSwitch = false, firstBatteryCheck = true, doSync = true;

	stepper.run();

	// ADC reads low if you sample too soon after startup
	// and battery check interval of 5 minutes means no accurate
	// display in ASCOM until after five minutes. So this first
	// delay should be late enough for accurate ADC reading but
	// fast enough to be available in ASCOM when the setup window
	// is opened.
	// Make both switches effectively one circuit so DIYers can use just one circuit
	// Determines opened or closed by the direction of travel before a switch was hit
	if (stepper.isRunning() == true)
	{
		if (digitalRead(CLOSED_PIN) == 0 && _shutterState != OPENING && hitSwitch == false)
		{
			hitSwitch = true;
			doSync = true;
			_shutterState = CLOSED;
			stepper.stop();
			DBPrintln("Hit closed switch");

		}
		if (digitalRead(OPENED_PIN) == 0 && _shutterState != CLOSING && hitSwitch == false)
		{
			hitSwitch = true;
			_shutterState = OPEN;
			stepper.stop();
			DBPrintln("Hit opened switch");
		}
		wasRunning = true;
		sendUpdates = true; // Set to false at the end of the rotator update steps. If running it'll get set back to true.
	}

	if (stepper.isRunning() == false && _shutterState != CLOSED && _shutterState != OPEN) _shutterState = ERROR;

	if (nextBatteryCheck < millis() && isConfiguringWireless == false)
	{
		DBPrintln("Measuring Battery");
		MeasureVoltage();
		Wireless.println("K" + GetVoltString());
		if (firstBatteryCheck == true)
		{
			nextBatteryCheck = millis() + 5000;
			firstBatteryCheck = false;
		}
		else
		{
			nextBatteryCheck = millis() + _batteryCheckInterval;
		}
	}

	if (stepper.isRunning() == true) return;

	if (doSync == true && digitalRead(CLOSED_PIN) == 0)
	{
			stepper.setCurrentPosition(0);
			doSync = false;
			DBPrintln("Stopped at closed position");
	}

	if (wasRunning == true) // So this bit only runs once after stopping.
	{
		DBPrintln("WasRunning " + String(_shutterState) + " Hitswitch " + String(hitSwitch));
		_lastButtonPressed = 0;
		wasRunning = false;
		hitSwitch = false;
	}
}
void		ShutterClass::Stop()
{
	stepper.stop();
}
#pragma endregion