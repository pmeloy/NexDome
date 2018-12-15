/*
* PDM NexDome Shutter kit firmware. NOT compatible with original NexDome ASCOM driver or Rotation kit firmware.
*
* Copyright (c) 2018 Patrick Meloy
* Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
*  files (the Software), to deal in the Software without restriction, including without limitation the rights to use, copy,
*  modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software
*  is furnished to do so, subject to the following conditions:
*  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*
*  THE SOFTWARE IS PROVIDED AS IS, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
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
// #define DEBUG
#ifdef DEBUG
#define DBPrint(x) Serial.print(x)
#define DBPrintln(x) Serial.println(x)
#else
#define DBPrint(x)
#define DBPrintln(x)
#endif // DEBUG
#pragma endregion

typedef struct _Configuration {
		int			signature;
		byte		sleepMode;
		uint16_t	sleepPeriod;
		uint16_t	sleepDelay;
		uint64_t	stepsPerStroke;
		uint16_t	acceleration;
		uint16_t	maxSpeed;
//		uint8_t		stepMode;
		uint8_t		reversed;
		uint16_t	cutoffVolts;
		byte		voltsClose;
		long int	rainCheckInterval;
		bool		radioIsConfigured;
} Configuration;

Configuration config;


#pragma region AccelStepper Setup

#define STEPPER_ENABLE_PIN			10
#define 	STEPPER_DIRECTION_PIN 	11
#define 	STEPPER_STEP_PIN			12

#define 	CLOSED_PIN		2
#define 	OPENED_PIN		3
#define 	BUTTON_OPEN		5
#define 	BUTTON_CLOSE	6

#define 	EEPROM_LOCATION   100
#define 	EEPROM_SIGNATURE 2000

AccelStepper stepper(AccelStepper::DRIVER, STEPPER_STEP_PIN, STEPPER_DIRECTION_PIN);
#pragma endregion

// need to make this global so we can access it in the interrupt
enum ShutterStates { OPEN, CLOSED, OPENING, CLOSING, ERROR };
ShutterStates	shutterState = ERROR;


#pragma region Shutter Header
class ShutterClass
{
public:

	// Constructor
	ShutterClass();

	bool		wasRunning = false;
	bool		sendUpdates = false;

	long int	rainCheckInterval;

	// Helper functions
	float		PositionToAltitude(long);
	long		AltitudeToPosition(float);

	bool		radioIsConfigured = false;
	bool	isConfiguringWireless = false;

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
	void		SetAcceleration(const uint16_t);
	void		SetMaxSpeed(const uint16_t);
	void		SetReversed(const bool);
	void		SetStepsPerStroke(const uint32_t);
	void		SetVoltsFromString(const String);

	// Movers
	void		DoButtons();
	void		Open();
	void		Close();
	void		GotoPosition(const unsigned long);
	void		GotoAltitude(const float);
	void		MoveRelative(const long);
	void		SetRainInterval(const int);
	byte		GetVoltsClose();
	void		SetVoltsClose(const byte);

	void		EnableOutputs(const bool);
	void		Run();
	void		Stop();
	void		ReadEEProm();
	void		WriteEEProm();

	static void		ClosedInterrupt();
	static void		OpenInterrupt();

private:

	byte			_sleepMode = 0;
	uint16_t		_sleepPeriod = 300;
	uint16_t		_sleepDelay = 30000;
	String			_ATString;
	int				_configStep;

	uint16_t		_acceleration;
	uint16_t		_maxSpeed;
	bool			_reversed;
//	uint8_t			_closedPin;
//	uint8_t			_openedPin;
//	uint8_t			_enablePin;

	float				_adcConvert;
	uint16_t		_volts;
	uint64_t		_batteryCheckInterval = 120000;
	uint16_t		_cutoffVolts = 1220;
	byte			_voltsClose = 0;

	uint8_t			_lastButtonPressed;

	uint64_t		_stepsPerStroke;
//	uint8_t			_stepMode;


	int		MeasureVoltage();
	void		DefaultEEProm();
};

#pragma endregion$

#pragma region Shutter CPP

#define VOLTAGE_MONITOR_PIN A0

ShutterClass::ShutterClass()
{
	_adcConvert = 3.0 * (5.0 / 1023.0) * 100;
	ReadEEProm();

	pinMode(CLOSED_PIN, INPUT_PULLUP);
	pinMode(OPENED_PIN, INPUT_PULLUP);
	pinMode(STEPPER_STEP_PIN, OUTPUT);
	pinMode(STEPPER_DIRECTION_PIN, OUTPUT);
	pinMode(STEPPER_ENABLE_PIN, OUTPUT);
	pinMode(BUTTON_OPEN, INPUT_PULLUP);
	pinMode(BUTTON_CLOSE, INPUT_PULLUP);
	pinMode(VOLTAGE_MONITOR_PIN, INPUT);

	ReadEEProm();
	SetAcceleration(_acceleration);
	SetMaxSpeed(_maxSpeed);
	stepper.setEnablePin(STEPPER_ENABLE_PIN);
	EnableOutputs(false);
	GetEndSwitchStatus();
	attachInterrupt(digitalPinToInterrupt(CLOSED_PIN), ClosedInterrupt, FALLING);
	attachInterrupt(digitalPinToInterrupt(OPENED_PIN), OpenInterrupt, FALLING);

}

void ShutterClass::ClosedInterrupt()
{
	// debounce
	if (digitalRead(CLOSED_PIN) == 0 && shutterState == CLOSING)
		stepper.stop();
}

void ShutterClass::OpenInterrupt()
{
	// debounce
	if (digitalRead(OPENED_PIN) == 0 && shutterState == OPENING)
		stepper.stop();
}

// EEPROM
void ShutterClass::DefaultEEProm()
{
	_sleepMode = 0;
	_sleepPeriod = 300;
	_sleepDelay = 30000;
	_stepsPerStroke = 885000;
	_acceleration = 7000;
	_maxSpeed = 5000;
	_reversed = false;
	_cutoffVolts = 1220;
	_voltsClose = 0;
	rainCheckInterval = 30000;
	radioIsConfigured = false;
}

void ShutterClass::ReadEEProm()
{
	Configuration cfg;
	//memset(&cfg, 0, sizeof(cfg));
	EEPROM.get(EEPROM_LOCATION, cfg);
	if (cfg.signature != EEPROM_SIGNATURE) {
		DBPrintln("Shutter invalid sig, defaults " + String(cfg.signature) + " = " + String(EEPROM_SIGNATURE));
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
	_cutoffVolts	= cfg.cutoffVolts;
	_voltsClose		= cfg.voltsClose;
	rainCheckInterval = cfg.rainCheckInterval;
	radioIsConfigured = cfg.radioIsConfigured;
}

void ShutterClass::WriteEEProm()
{
	Configuration cfg;

	DBPrintln("Signature is " + String(EEPROM_SIGNATURE));
	cfg.signature		= EEPROM_SIGNATURE;
	cfg.sleepMode		= _sleepMode;
	cfg.sleepPeriod		= _sleepPeriod;
	cfg.sleepDelay		= _sleepDelay;
	cfg.stepsPerStroke	= _stepsPerStroke;
	cfg.acceleration	= _acceleration;
	cfg.maxSpeed		= _maxSpeed;
	cfg.cutoffVolts		= _cutoffVolts;
	cfg.voltsClose		= _voltsClose;
	cfg.rainCheckInterval = rainCheckInterval;
	cfg.radioIsConfigured = radioIsConfigured;

	EEPROM.put(EEPROM_LOCATION, cfg);
	DBPrintln("Wrote sig of " + String(cfg.signature));
}

// INPUTS
void ShutterClass::DoButtons()
{
	int PRESSED = 0;
	static int whichButtonPressed = 0, lastButtonPressed = 0;

	if (digitalRead(BUTTON_OPEN) == PRESSED && whichButtonPressed == 0 && GetEndSwitchStatus() != OPEN) {
		DBPrintln("Button Open Shutter");
		whichButtonPressed = BUTTON_OPEN;
		shutterState = OPENING;
		MoveRelative(_stepsPerStroke);
		lastButtonPressed = BUTTON_OPEN;
	}
	else if (digitalRead(BUTTON_CLOSE) == PRESSED && whichButtonPressed == 0 && GetEndSwitchStatus() != CLOSED) {
		DBPrintln("Button Close Shutter");
		whichButtonPressed = BUTTON_CLOSE;
		shutterState = CLOSING;
		MoveRelative(1 - _stepsPerStroke);
		lastButtonPressed = BUTTON_CLOSE;
	}

	if (digitalRead(whichButtonPressed) == !PRESSED && lastButtonPressed > 0) {
		Stop();
		lastButtonPressed = whichButtonPressed = 0;
	}
}

int ShutterClass::MeasureVoltage()
{
	int adc;
	float calc;

	adc = analogRead(VOLTAGE_MONITOR_PIN);
	DBPrintln("ADC returns " + String(adc));
	calc = adc * _adcConvert;
	return int(calc);
}

// Helper functions
long ShutterClass::AltitudeToPosition(const float alt)
{
	long result;

	result = (long)(_stepsPerStroke * alt / 90.0);
	return result;
}

float ShutterClass::PositionToAltitude(const long pos)
{
	float result = (float)pos;
	result = result / _stepsPerStroke * 90.0;
	return result;
}

// Wireless Functions

// Getters
int32_t ShutterClass::GetAcceleration()
{
	return _acceleration;
}

int ShutterClass::GetEndSwitchStatus()
{
	int result= ERROR;

	if (digitalRead(CLOSED_PIN) == 0)
		result = CLOSED;

	if (digitalRead(OPENED_PIN) == 0)
		result = OPEN;
	return result;
}

float ShutterClass::GetElevation()
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
	return (short)shutterState;
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

String ShutterClass::GetVoltString()
{
	return String(_volts) + "," + String(_cutoffVolts);
}

// Setters
void ShutterClass::EnableOutputs(const bool newState)
{
	if (newState == false) {
		digitalWrite(STEPPER_ENABLE_PIN, 1);
		DBPrintln("Outputs disabled");
	}
	else {
		digitalWrite(STEPPER_ENABLE_PIN, 0);
		DBPrintln("Outputs Enabled");
	}
}

void ShutterClass::SetAcceleration(const uint16_t accel)
{
	_acceleration = accel;
	stepper.setAcceleration(accel);
	WriteEEProm();
}

void ShutterClass::SetMaxSpeed(const uint16_t speed)
{
	_maxSpeed = speed;
	stepper.setMaxSpeed(speed);
	WriteEEProm();
}

void ShutterClass::SetReversed(const bool reversed)
{
	_reversed = reversed;
	stepper.setPinsInverted(reversed, reversed, reversed);
	WriteEEProm();
}

void ShutterClass::SetStepsPerStroke(const uint32_t newSteps)
{
	_stepsPerStroke = newSteps;
	WriteEEProm();
}

void ShutterClass::SetVoltsFromString(const String value)
{
	_cutoffVolts = value.toInt();
	WriteEEProm();
}

// Movers
void ShutterClass::Open()
{
	shutterState = OPENING;
	MoveRelative(_stepsPerStroke * 1.2);
}

void ShutterClass::Close()
{
	shutterState = CLOSING;
	MoveRelative(1 - _stepsPerStroke * 1.2);
}

void ShutterClass::GotoPosition(const unsigned long newPos)
{
	uint64_t currentPos = stepper.currentPosition();
	bool doMove = false;

	// Check if this actually changes position, then move if necessary.
	if (newPos > currentPos) {
		shutterState = OPENING;
		doMove = true;
	}
	else if (newPos < currentPos) {
		shutterState = CLOSING;
		doMove = true;
	}

	if (doMove) {
		EnableOutputs(true);
		stepper.moveTo(newPos);
	}
}

void ShutterClass::GotoAltitude(const float newAlt)
{

	GotoPosition(AltitudeToPosition(newAlt));
}

void ShutterClass::MoveRelative(const long amount)
{
	EnableOutputs(true);
	stepper.move(amount);
}

inline void ShutterClass::SetRainInterval(const int newInterval)
{
	rainCheckInterval = newInterval;
	WriteEEProm();
}

inline void ShutterClass::SetVoltsClose(const byte value)
{
	_voltsClose = value;
	WriteEEProm();
}

inline byte ShutterClass::GetVoltsClose()
{
	return _voltsClose;
}

void ShutterClass::Run()
{
	static uint64_t nextBatteryCheck = 0;
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

	if (digitalRead(CLOSED_PIN) == 0 && shutterState != OPENING && hitSwitch == false) {
			hitSwitch = true;
			doSync = true;
			shutterState = CLOSED;
			stepper.stop();
			DBPrintln("Hit closed switch");

	}

	if (digitalRead(OPENED_PIN) == 0 && shutterState != CLOSING && hitSwitch == false) {
			hitSwitch = true;
			shutterState = OPEN;
			stepper.stop();
			DBPrintln("Hit opened switch");
	}

	if (stepper.isRunning()) {
		wasRunning = true;
		sendUpdates = true; // Set to false at the end of the rotator update steps. If running it'll get set back to true.
	}

	if (stepper.isRunning() == false && shutterState != CLOSED && shutterState != OPEN)
		shutterState = ERROR;

	if (nextBatteryCheck < millis() && isConfiguringWireless == false) {
		DBPrintln("Measuring Battery");
		_volts = MeasureVoltage();
		Wireless.println("K" + GetVoltString());
		if (firstBatteryCheck) {
			nextBatteryCheck = millis() + 5000;
			firstBatteryCheck = false;
		}
		else {
			nextBatteryCheck = millis() + _batteryCheckInterval;
		}
	}

	if (stepper.isRunning())
		return;

	if (doSync && digitalRead(CLOSED_PIN) == 0) {
			stepper.setCurrentPosition(0);
			doSync = false;
			DBPrintln("Stopped at closed position");
	}

	if (wasRunning) { // So this bit only runs once after stopping.
		DBPrintln("WasRunning " + String(shutterState) + " Hitswitch " + String(hitSwitch));
		_lastButtonPressed = 0;
		wasRunning = false;
		hitSwitch = false;
		EnableOutputs(false);
	}
}

void		ShutterClass::Stop()
{
	stepper.stop();
}

#pragma endregion
