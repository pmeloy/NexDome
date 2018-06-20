/*
* PDM NexDome Rotation kit firmware. NOT compatible with original NexDome ASCOM driver.
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
#pragma once
#include <EEPROM.h>
#include <AccelStepper.h>

#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif


//#define DEBUG
//#ifdef DEBUG
//#define DBPrint(x) Serial.print(x)
//#define DebugPrint(x) Serial.println(x)
//#else
//#define DBPrint(x)
//#define DebugPrint(x)
//#endif // DEBUG

//const int NEVER_HOMED = -1;
//const int HOMED = 0;
//const int ATHOME = 1;

const int HOME_PIN = 2;					// Also used for Shutter open status
const int STEPPER_ENABLE_PIN = 10;		// Digital Output
const int DIRECTION_PIN = 11;	// Digital Output
const int STEP_PIN = 12;			// Digital Output
const int BUTTON_CCW = 5;				// Digital Input
const int BUTTON_CW = 6;				// Digital Input
const int RAIN_SENSOR_PIN = 7;		// Digital Input from RG11
AccelStepper stepper(AccelStepper::DRIVER, STEP_PIN, DIRECTION_PIN);

#define VOLTAGE_MONITOR_PIN A0


class RotatorClass
{

public:
	enum HomeStatuses
	{
		NEVER_HOMED,
		HOMED,
		ATHOME
	};
	enum Seeks
	{
		HOMING_NONE, // Not homing or calibrating
		HOMING_HOME, // Homing
		CALIBRATION_MOVEOFF, // Ignore home until we've moved off while measuring the dome.
		CALIBRATION_MEASURE // Measuring dome until home hit again.
	};

	RotatorClass();
	int			rainCheckInterval; // in seconds, function  multiplies by 1000
	bool		rainCheckTwice = false; // Seconds of rain sensor being on before we react. 

	// Debugging
	byte		debugEnabled = 1;
	void		DebugPrint(String);
	// Getters
	bool		GetRainStatus();
	int			GetLowVoltageCutoff();
	bool		GetVoltsAreLow();
	String		GetVoltString();
	long		GetPosition();
	int			GetSeekMode();
	int			GetDirection();
	long		GetMaxSpeed();
	long		GetAcceleration();
	long		GetStepsPerRotation();
	bool		GetReversed();
	float		GetAzimuth();
	float		GetHomeAzimuth();
	int			GetHomeStatus();

	float		GetParkAzimuth();
	long		GetAzimuthToPosition(float);

	// Setters
	void		SetLowVoltageCutoff(int);
	void		SetPosition(long);
	void		SetMaxSpeed(long);
	void		SetAcceleration(long);
	void		SetAzimuth(float);
	void		SetParkAzimuth(float);
	void		SetStepsPerRotation(long);
	void		SetRainInterval(uint16_t);
	void		SetReversed(bool reversed);
	void		SetHomeAzimuth(float);

	// Movers
	void		MoveRelative(long steps);
	void		Stop();
	void		Run();


	// Homing and Calibration
	void		StartHoming();
	void		StartCalibrating();
	void		Calibrate();
	void		SyncPosition(float);
	void		SyncHome(float);


private:

	typedef struct RotatorConfiguration
	{
		int			signature;
		long		maxSpeed;
		long		acceleration;
		long		stepsPerRotation;
		bool		reversed;
		float		homeAzimuth;
		float		parkAzimuth;
		int			cutoffVolts;
		int			rainCheckInterval;
		bool		rainCheckTwice;
	} RotatorConfig;

	const int	_signature = 8022;
	const int	_eepromLocation = 10;
	const long	_STEPSFORROTATION = 55100;


	// Stepper motor DongZheng Motor Co.
	// 2.5V 2.8A 1:15 1.8D/step
	// Model 56JXS300K15G
	// 3000 steps per rev, 6912mm travel
	long		_maxSpeed;
	long		_acceleration;

	// Inputs
	int			_btnCCWPin;
	int			_btnCWpin;
	int			_rainPin;

	// Rotator properties
	float		_homeAzimuth = 0;
	float		_parkAzimuth = 0;

	RotatorConfig cfg;

	// Rotator
	bool		_isAtHome;
	bool		_hasBeenHomed;
	enum Seeks	_seekMode;
	bool		_SetToHomeAzimuth, _doStepsPerRotation;
	bool		_reversed;
	long		_stepsToStop;
	long		_stepsPerRotation;
	float		_stepsPerDegree;
	unsigned long	_moveOffUntil;
	

	// movement
	const int	MOVE_NEGATIVE = -1;
	const int	MOVE_NONE = 0;
	const int	MOVE_POSITIVE = 1;
	int			_moveDirection;

	// Power values
	int			_volts;
	int			_cutOffVolts;
	int			ReadVolts();

	// Utility
	long		GetPositionalDistance(long, long);

	void		ButtonCheck();

	void		SaveToEEProm();
	bool		LoadFromEEProm();
	void		SetDefaultConfig();
	void		WipeConfig();

	void		enableMotor(bool);
	float		GetAngularDistance(float fromAngle, float toAngle);

};

RotatorClass::RotatorClass()
{
	LoadFromEEProm();
	pinMode(HOME_PIN, INPUT_PULLUP);
	pinMode(STEP_PIN, OUTPUT);
	pinMode(DIRECTION_PIN, OUTPUT);
	pinMode(STEPPER_ENABLE_PIN, OUTPUT);
	pinMode(BUTTON_CCW, INPUT_PULLUP);
	pinMode(BUTTON_CW, INPUT_PULLUP);
	pinMode(RAIN_SENSOR_PIN, INPUT_PULLUP);
	pinMode(VOLTAGE_MONITOR_PIN, INPUT);

	stepper.setMaxSpeed(5000);
	stepper.setAcceleration(7000);
}

#pragma region "Controller Related"
void RotatorClass::SaveToEEProm()
{
	RotatorConfiguration cfg;

	memset(&cfg, 0, sizeof(cfg));

	cfg.signature = _signature;
	cfg.maxSpeed = _maxSpeed;
	cfg.acceleration = _acceleration;
	cfg.stepsPerRotation = _stepsPerRotation;
	cfg.reversed = _reversed;
	cfg.homeAzimuth = _homeAzimuth;
	cfg.parkAzimuth = _parkAzimuth;
	cfg.cutoffVolts = _cutOffVolts;
	cfg.rainCheckInterval = rainCheckInterval;
	cfg.rainCheckTwice = rainCheckTwice;

	EEPROM.put(_eepromLocation, cfg);

}

bool RotatorClass::LoadFromEEProm()
{
	RotatorConfiguration cfg;
	bool response = true;

	//  zero the structure so currently unused parts
	//  dont end up loaded with random garbage
	memset(&cfg, 0, sizeof(cfg));

	EEPROM.get(_eepromLocation, cfg);
	if (cfg.signature != _signature)
	{
		SetDefaultConfig();
		response = false;
	}
	else
	{
		_maxSpeed = cfg.maxSpeed;
		_acceleration = cfg.acceleration;
		_stepsPerRotation = cfg.stepsPerRotation;
		_reversed = cfg.reversed;
		_homeAzimuth = cfg.homeAzimuth;
		_parkAzimuth = cfg.parkAzimuth;
		_cutOffVolts = cfg.cutoffVolts;
		rainCheckInterval = cfg.rainCheckInterval;
		rainCheckTwice = cfg.rainCheckTwice;
	}

	SetMaxSpeed(_maxSpeed);
	SetAcceleration(_acceleration);
	SetStepsPerRotation(_stepsPerRotation);
	SetReversed(_reversed);
	return response;
}
void RotatorClass::SetDefaultConfig()
{
	_maxSpeed = 5000;
	_acceleration = 8000;
	_stepsPerRotation = 440800;
	_reversed = 0;
	_homeAzimuth = 0;
	_parkAzimuth = 0;
	_cutOffVolts = 1220;
	rainCheckInterval = 30; // In seconds, function will x 10
	rainCheckTwice = false;

}
void RotatorClass::WipeConfig()
{
	RotatorConfiguration cfg;
	memset(&cfg, 0, sizeof(cfg));
	EEPROM.put(_eepromLocation, cfg);
}

int	RotatorClass::ReadVolts()
{
	int volts;

	volts = analogRead(VOLTAGE_MONITOR_PIN);
	volts = volts / 2;
	volts = volts * 3;
	_volts = volts;
	return volts;
}
void RotatorClass::SetLowVoltageCutoff(int lowVolts)
{
	_cutOffVolts = lowVolts;
	SaveToEEProm();
}
int	RotatorClass::GetLowVoltageCutoff()
{
	return _cutOffVolts;
}
inline bool RotatorClass::GetVoltsAreLow()
{
	bool voltsLow = false;

	if (_volts <= _cutOffVolts) voltsLow = true;
	return voltsLow;
}
inline String RotatorClass::GetVoltString()
{
	return String(_volts) + "," + String(_cutOffVolts);
}
#pragma endregion

#pragma region "I/O"
void RotatorClass::ButtonCheck()
{
	int PRESSED = 0;
	static int whichButtonPressed = 0, lastButtonPressed = 0;

	if (digitalRead(BUTTON_CW) == PRESSED && whichButtonPressed == 0)
	{
		whichButtonPressed = BUTTON_CW;
		MoveRelative(_stepsPerRotation);
		lastButtonPressed = BUTTON_CW;
	}
	else if (digitalRead(BUTTON_CCW) == PRESSED && whichButtonPressed == 0)
	{
		whichButtonPressed = BUTTON_CCW;
		MoveRelative(1 - _stepsPerRotation);
		lastButtonPressed = BUTTON_CCW;
	}

	if (digitalRead(whichButtonPressed) == !PRESSED && lastButtonPressed > 0)
	{
		Stop();
		lastButtonPressed = whichButtonPressed = 0;
	}
}
inline void RotatorClass::DebugPrint(String msg)
{
	if (debugEnabled == 1)
	{
		Serial.print("%" + msg + "#");
	}
}
bool RotatorClass::GetRainStatus()
{
	static int rainCount = 0;
	bool isRaining = false;
	if (rainCheckTwice == false) rainCount = 1;

	if (digitalRead(RAIN_SENSOR_PIN) == 1)
	{
		rainCount = 0;
	}
	else
	{ 
		if (digitalRead(RAIN_SENSOR_PIN) == 0) 
		{
			if (rainCount == 1)
			{
				isRaining = true;
			}
			else
			{
				rainCount = 1;
			}
		}
	}
	return isRaining;
}
#pragma endregion

#pragma region "Stepper Related"
void RotatorClass::enableMotor(bool newState)
{
	if (newState == false)
	{
		digitalWrite(STEPPER_ENABLE_PIN, 1);
		DebugPrint("Outputs disabled");
	}
	else
	{
		digitalWrite(STEPPER_ENABLE_PIN, 0);
		DebugPrint("Outputs Enabled");
	}

}
long RotatorClass::GetMaxSpeed()
{
	return _maxSpeed;
}
void RotatorClass::SetMaxSpeed(long newSpeed)
{
	DebugPrint("Rotator set max speed to " + String(newSpeed));
	_maxSpeed = newSpeed;
	stepper.setMaxSpeed(newSpeed);
	SaveToEEProm();
}
long RotatorClass::GetAcceleration()
{
	return _acceleration;
}
void RotatorClass::SetAcceleration(long newAccel)
{
	DebugPrint("Rotator set acceleration to " + String(newAccel));
	_acceleration = newAccel;
	stepper.setAcceleration(newAccel);
	SaveToEEProm();
}
bool RotatorClass::GetReversed()
{
	return _reversed;
}
void RotatorClass::SetReversed(bool isReversed)
{
	_reversed = isReversed;
	stepper.setPinsInverted(isReversed, isReversed, isReversed);
	SaveToEEProm();
}
long RotatorClass::GetStepsPerRotation()
{
	return _stepsPerRotation;
}
void RotatorClass::SetStepsPerRotation(long newCount)
{
	_stepsPerDegree = (float)newCount / 360.0;
	_stepsPerRotation = newCount;
	SaveToEEProm();
}
inline void RotatorClass::SetRainInterval(uint16_t interval)
{
	rainCheckInterval = interval;
	SaveToEEProm();
}
#pragma endregion

#pragma region "Homing and Calibrating"
void RotatorClass::StartHoming()
{
	float diff;
	long distance;

	if (_isAtHome == true) return;
	diff = GetAngularDistance(GetAzimuth(), GetHomeAzimuth());
	_moveDirection = MOVE_POSITIVE;
	if (diff < 0) _moveDirection = MOVE_NEGATIVE;
	distance = (_stepsPerRotation  * _moveDirection * 1.5);
	_seekMode = HOMING_HOME;
	MoveRelative(distance);
}
void RotatorClass::StartCalibrating()
{
	if (_isAtHome == false) return;
	_seekMode = CALIBRATION_MOVEOFF;
	stepper.setCurrentPosition(0);
	_moveOffUntil = millis() + 5000;
	DebugPrint("Rotator move off from " + String(millis()) + " to " + String(_moveOffUntil));
	_doStepsPerRotation = false;
	MoveRelative(_stepsPerRotation  * 1.5);
}
void RotatorClass::Calibrate()
{
	static long stopDelay, homePositionEnd, currentPosition;

	if (_seekMode > HOMING_HOME)
	{
		switch (_seekMode)
		{
		case(CALIBRATION_MOVEOFF):
			if (millis() >= _moveOffUntil)
			{
				DebugPrint("Rotator move off complete");
				_seekMode = CALIBRATION_MEASURE;
			}
			break;
		case(CALIBRATION_MEASURE):
			if (digitalRead(HOME_PIN) == 0)
			{
				stepper.stop();
				_seekMode = HOMING_NONE;
				_hasBeenHomed = true;
				_SetToHomeAzimuth = true;
				_doStepsPerRotation = true; // Once stopped, set SPR to stepper position and save to eeprom.
			}
			break;
		}
	}
}
void RotatorClass::SetHomeAzimuth(float newHome)
{
	_homeAzimuth = newHome;
	SaveToEEProm();
}
float RotatorClass::GetHomeAzimuth()
{
	return _homeAzimuth;
}
void RotatorClass::SyncHome(float newAzimuth)
{
	float delta, currentAzimuth;

	delta = GetAngularDistance(GetAzimuth(), newAzimuth);
	delta = delta + _homeAzimuth;
	if (delta < 0) delta = 360.0 + delta;
	if (delta >= 360.0) delta -= 360.0;
	_homeAzimuth = delta;
	SaveToEEProm();
}
int	RotatorClass::GetHomeStatus()
{
	int status = NEVER_HOMED;

	if (_hasBeenHomed == true) status = HOMED;
	if (_isAtHome == true) status = ATHOME;
	return status;
}
void RotatorClass::SetParkAzimuth(float newPark)
{
	_parkAzimuth = newPark;
	SaveToEEProm();
}
float RotatorClass::GetParkAzimuth()
{
	return _parkAzimuth;
}
int	RotatorClass::GetSeekMode()
{
	return _seekMode;
}
#pragma endregion

#pragma region "Positioning"
long RotatorClass::GetAzimuthToPosition(float azimuth)
{
	long newPosition;

	newPosition = (float)_stepsPerRotation / (float)360 * azimuth;
	return newPosition;
}
void RotatorClass::SyncPosition(float newAzimuth)
{
	long newPosition;

	newPosition = GetAzimuthToPosition(newAzimuth);
	stepper.setCurrentPosition(newPosition);
	//SaveToEEProm();
}
long RotatorClass::GetPosition()
{
	/// Return change in steps relative to
	/// last sync position
	long position;
	position = stepper.currentPosition();
	if (_seekMode < CALIBRATION_MOVEOFF) 
	{
		while (position >= _stepsPerRotation) position -= _stepsPerRotation;
		while (position < 0) position += _stepsPerRotation;
	}
	return position;
}
void RotatorClass::SetPosition(long newPosition)
{
	/// Set movement tarGet by step position

	long currentPosition;

	enableMotor(true);
	currentPosition = GetPosition();

	if (newPosition > currentPosition)
	{
		_moveDirection = MOVE_POSITIVE;
	}
	else
	{
		_moveDirection = MOVE_NEGATIVE;
	}
	enableMotor(true);
	stepper.moveTo(newPosition);
	return;
}
void RotatorClass::MoveRelative(long howFar)
{
	// Use by Home and Calibrate
	// Tells dome to rotate more than 360 degrees
	// from current position. Stopped only by
	// homing or calibrating routine.
	enableMotor(true);
	_moveDirection = -1;
	if (howFar > 0) _moveDirection = 1;
	stepper.move(howFar);
}
int	RotatorClass::GetDirection()
{
	return _moveDirection;
}
float RotatorClass::GetAngularDistance(float fromAngle, float toAngle)
{
	float delta;
	delta = toAngle - fromAngle;
	if (delta == 0) return 0; //  we are already there

	if (delta > 180) delta -= 360;
	if (delta < -180) delta += 360;
	return delta;
}
long RotatorClass::GetPositionalDistance(long fromPosition, long toPosition)
{
	long delta;
	delta = toPosition - fromPosition;
	if (delta == 0) return 0; //  we are already there

	if (delta > _stepsPerRotation / 2) delta -= _stepsPerRotation;
	if (delta < -_stepsPerRotation / 2) delta += _stepsPerRotation;
	return delta;

}
void RotatorClass::SetAzimuth(float newHeading)
{
	// Set movement tarGet by compass azimuth
	float currentHeading, tarGetPosition;
	float delta;
	float newdelta;
	currentHeading = GetAzimuth();
	delta = GetAngularDistance(currentHeading, newHeading) * _stepsPerDegree;
	MoveRelative(delta);
}
float RotatorClass::GetAzimuth()
{
	/* floating point math for Get azimuth
	*  prefer floats for accurately placing
	*  the power pickup to charge the shutter
	*  but it introduces significant processing
	*  overhead
	*/
	float azimuth = 0;
	long currentPosition = 0;

	currentPosition = GetPosition();
	if (currentPosition != 0) azimuth = (float)GetPosition() / (float)_stepsPerRotation * 360.0;
	//  in case we need to do another step
	//  do a run sequence now
	while (azimuth < 0) azimuth += 360.0;
	while (azimuth >= 360.0) azimuth -= 360.0;

	return azimuth;
}
#pragma endregion

#pragma region "Movement"
void RotatorClass::Run()
{
	static bool wasRunning = false;
	static long nextPeriodicReading;
	long stepsFromZero;
	int nextCheck;

	if (millis() > nextCheck)
	{
		nextCheck += 10;
		ButtonCheck();
	}
	if (nextPeriodicReading < millis())
	{
		_volts = ReadVolts();
		nextPeriodicReading = millis() + 10000;
	}
	
	_isAtHome = false; // default to not at home switch

	if (_seekMode > HOMING_HOME) Calibrate();

	if (digitalRead(HOME_PIN) == 0) DebugPrint("Rotator hit home switch");

	if (stepper.run() == true)
	{

		wasRunning = true;
		if (_seekMode == HOMING_HOME && digitalRead(HOME_PIN) == 0) // We're looking for home and found it
		{
			Stop();
			_SetToHomeAzimuth = true; // Need to set current az to homeaz but not until rotator is stopped;
			_seekMode = HOMING_NONE;
			_hasBeenHomed = true;
		}
		return;
	}

	if (stepper.isRunning()) return;

	// Won't get here if stepper is moving
	if (digitalRead(HOME_PIN) == 0 ) // Not moving but we're at home
	{
		_isAtHome = true;
		if (_hasBeenHomed == false) // Just started up rotator so tell rotator its at home.
		{
			SyncPosition(_homeAzimuth); // Set the Azimuth to the home position
			_hasBeenHomed = true; // We've been homed
		}
	}

	if (wasRunning == true)
	{
		DebugPrint("Rotator stopped!");
		_moveDirection = MOVE_NONE;

		if (_doStepsPerRotation == true)
		{
			_stepsPerRotation = stepper.currentPosition();
			SyncHome(_homeAzimuth);
			SaveToEEProm();
			_doStepsPerRotation = false;
			Serial.print("t" + String(_stepsPerRotation) +"#");
		}

		stepsFromZero = GetPosition();
		if (stepsFromZero < 0)
		{
			while (stepsFromZero < 0) stepsFromZero += _stepsPerRotation;
			stepper.setCurrentPosition(stepsFromZero);
		}
		if (stepsFromZero > _stepsPerRotation)
		{
			while (stepsFromZero > _stepsPerRotation) stepsFromZero -= _stepsPerRotation;
			stepper.setCurrentPosition(stepsFromZero);
		}
		if (_SetToHomeAzimuth == true)
		{
			SyncPosition(_homeAzimuth);
			_SetToHomeAzimuth = false;
		}
		enableMotor(false);
		wasRunning = false;
	}
}
void RotatorClass::Stop()
{
	// It takes approximately RunSpeed/3.95 steps to stop
	// Use this to calculate a full step stopping position
	// Actual divisor appears to be 3.997 but this leaves a
	// few extra steps for getting to a full step position.

	if (!stepper.run()) return;
	_seekMode = HOMING_NONE;
	stepper.stop();
}
#pragma endregion
