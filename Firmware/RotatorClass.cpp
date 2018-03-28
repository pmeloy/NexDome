#pragma once
#include "RotatorClass.h"
#include <AccelStepper.h>
//#include <EEPROM.h>

// 
// For version 0.3
// 
#pragma region "Declarations"
const int HOME_PIN = 2;					// Also used for Shutter open status
const int STEPPER_ENABLE_PIN = 10;		// Digital Output
const int STEPPER_DIRECTION_PIN = 11;	// Digital Output
const int STEPPER_STEP_PIN = 12;			// Digital Output
const int BUTTON_CCW = 5;				// Digital Input
const int BUTTON_CW = 6;				// Digital Input
const int RAIN_SENSOR_PIN = 7;		// Digital Input from RG11

AccelStepper stepper(AccelStepper::DRIVER, STEPPER_STEP_PIN, STEPPER_DIRECTION_PIN);

const int NEVER_HOMED = -1;
const int HOMED = 0;
const int ATHOME = 1;

#pragma endregion

Rotator::Rotator()
{
	loadConfig();
	_homePin = HOME_PIN;
	pinMode(HOME_PIN, INPUT_PULLUP);
	pinMode(STEPPER_STEP_PIN, OUTPUT);
	pinMode(STEPPER_DIRECTION_PIN, OUTPUT);
	pinMode(STEPPER_ENABLE_PIN, OUTPUT);
	pinMode(BUTTON_CCW, INPUT_PULLUP);
	pinMode(BUTTON_CW, INPUT_PULLUP);
	pinMode(RAIN_SENSOR_PIN, INPUT_PULLUP);
	pinMode(VOLTAGE_MONITOR_PIN, INPUT);

	stepper.setMaxSpeed(1000);
	stepper.setAcceleration(2000);
}

#pragma region "Controller Related"
void		Rotator::saveConfig()
{
	RotatorConfiguration cfg;

	memset(&cfg, 0, sizeof(cfg));

	cfg.signature = _signature;
	cfg.stepMode = _stepMode;
	cfg.maxSpeed = _maxSpeed;
	cfg.acceleration = _acceleration;
	cfg.stepsPerRotation = _stepsPerRotation;
	cfg.homeCenter = _homeCenter;
	cfg.reversed = _reversed;
	cfg.homeAzimuth = _homeAzimuth;
	cfg.parkAzimuth = _parkAzimuth;
	cfg.cutoffVolts = _cutoffVolts;

	EEPROM.put(_eepromLocation, cfg);

}
bool		Rotator::loadConfig()
{
	RotatorConfiguration cfg;
	bool response = true;

	//  zero the structure so currently unused parts
	//  dont end up loaded with random garbage
	memset(&cfg, 0, sizeof(cfg));

	EEPROM.get(_eepromLocation, cfg);
	if (cfg.signature != _signature)
	{
		setDefaults();
		response = false;
	}
	else
	{
		_stepMode = cfg.stepMode;
		_maxSpeed = cfg.maxSpeed;
		_acceleration = cfg.acceleration;
		_stepsPerRotation = cfg.stepsPerRotation;
		_homeCenter = cfg.homeCenter;
		_reversed = cfg.reversed;
		_homeAzimuth = cfg.homeAzimuth;
		_parkAzimuth = cfg.parkAzimuth;
		_cutoffVolts = cfg.cutoffVolts;
	}

	setStepMode(_stepMode);
	setMaxSpeed(_maxSpeed);
	setAcceleration(_acceleration);
	setStepsPerRotation(_stepsPerRotation);
	setReversed(_reversed);
	return response;
}
void		Rotator::setDefaults()
{
	_stepMode = 8;
	_maxSpeed = 5000;
	_acceleration = 8000;
	_stepsPerRotation = 440800;
	_homeCenter = 0;
	_stepsToStop = 0;
	_reversed = 0;
	_homeAzimuth = 0;
	_parkAzimuth = 0;
	_cutoffVolts = 11;

}
void		Rotator::wipeConfig()
{
	RotatorConfiguration cfg;
	memset(&cfg, 0, sizeof(cfg));
	EEPROM.put(_eepromLocation, cfg);
}

int			Rotator::getControllerVoltage()
{
	int volts;

	volts = analogRead(VOLTAGE_MONITOR_PIN);
	volts = volts / 2;
	volts = volts * 3;
	_controllerVolts = volts;
	return volts;
}
void		Rotator::setLowVoltageCutoff(int lowVolts)
{
	_cutoffVolts = lowVolts;
}
int			Rotator::getLowVoltageCutoff()
{
	return _cutoffVolts;
}
#pragma endregion

#pragma region "I/O"
void		Rotator::buttonCheck()
{
	unsigned long int moveSize = 1000;
	int PRESSED = 0;

	if (digitalRead(BUTTON_CW) == PRESSED)
	{
		_moveDirection = MOVE_POSITIVE;
		moveRelative(moveSize * _moveDirection);
	}
	else if (digitalRead(BUTTON_CCW) == PRESSED)
	{
		_moveDirection = MOVE_NEGATIVE;
		moveRelative(moveSize * _moveDirection);
	}
}
bool		Rotator::isRaining()
{
	return !digitalRead(_rainPin);
}
#pragma endregion

#pragma region "Stepper Related"
void		Rotator::enableMotor(bool newState)
{
	stepper.setEnablePin(newState);
}
float		Rotator::getMaxSpeed()
{
	return _maxSpeed;
}
void		Rotator::setMaxSpeed(float newSpeed)
{
	_maxSpeed = newSpeed;
	stepper.setMaxSpeed(newSpeed);
	saveConfig();
}
float		Rotator::getAcceleration()
{
	return _acceleration;
}
void		Rotator::setAcceleration(float newAccel)
{
	_acceleration = newAccel;
	stepper.setAcceleration(newAccel);
	saveConfig();
}
bool		Rotator::getReversed()
{
	return _reversed;
}
void		Rotator::setReversed(bool isReversed)
{
	_reversed = isReversed;
	stepper.setPinsInverted(isReversed, isReversed, isReversed);
	saveConfig();
}
int			Rotator::getStepMode()
{
	return _stepMode;
}
void		Rotator::setStepMode(int newMode)
{
	_stepMode = newMode;
	saveConfig();
}
long int	Rotator::getStepsPerRotation()
{
	return _stepsPerRotation;
}
void		Rotator::setStepsPerRotation(long int newCount)
{
	_stepsPerDegree = (float)newCount / 360.0;
	_stepsPerRotation = newCount;
	saveConfig();
}
#pragma endregion

#pragma region "Homing and Calibrating"
void		Rotator::startHoming(bool calibrating)
{
	float diff;
	long int distance;

	String msg;
	diff = getAngularDistance(getAzimuth(), getHomeAzimuth());
	_moveDirection = MOVE_POSITIVE;
	if (diff < 1) _moveDirection = MOVE_NEGATIVE;
	if (calibrating == false)
	{
		_seekMode = HOMING_HOME;
	}
	else
	{
		_seekMode = CALIBRATION_START;
		stepper.setCurrentPosition(0);
	}

	distance = (_stepsPerRotation  * _moveDirection * 1.2);
	moveRelative(distance);
}
void		Rotator::doHomeOrCalibrate()
{
	// Check for home switch hit every 250ms
	static long int nextCheck, moveOffDelay, homePositionStart, homePositionEnd, currentPosition;
	static bool lastSwitchState;

	if (millis() > nextCheck)
	{
		nextCheck += 5;
		if (digitalRead(HOME_PIN) == 0)
		{
			_isAtHome = true;
		}
		else
		{
			_isAtHome = false;
		}
	}

	if (_seekMode > HOMING_NONE)
	{
		switch (_seekMode)
		{
		case(HOMING_HOME):
			if (_isAtHome == true)
			{
				homeHit();
				_seekMode = HOMING_NONE;
				stop();
			}
			break;
		case(CALIBRATION_START):
			if (_isAtHome == true)
			{
				homePositionStart = stepper.currentPosition();
				moveOffDelay = millis() + 5000; // 5 seconds to get off the home switch
				_seekMode = CALIBRATION_MOVEOFF;
			}
			break;
		case(CALIBRATION_MOVEOFF):
			if (millis() >= moveOffDelay)
			{
				_seekMode = CALIBRATION_MEASURE;
				lastSwitchState = false;
			}
			break;
		case(CALIBRATION_MEASURE):
			if (_isAtHome == true)
			{
				_seekMode = HOMING_NONE;
				lastSwitchState = false;
				currentPosition = stepper.currentPosition() - homePositionStart;
				_stepsPerRotation = abs(currentPosition);
				homeHit();
				saveConfig();
			}
			else
				break;
		}
	}
}
void		Rotator::homeHit()
{
	long int decelerationSteps;
	_seekMode = HOMING_NONE;
	_hasBeenHomed = true;
	_doSync = true;
	stop();
}
void		Rotator::setHomeAzimuth(float newHome)
{
	_homeAzimuth = newHome;
	saveConfig();
}
float		Rotator::getHomeAzimuth()
{
	return _homeAzimuth;
}
void		Rotator::syncHome(float newAzimuth)
{
	float delta, currentAzimuth;

	delta = getAngularDistance(getAzimuth(), newAzimuth);
	delta = delta + _homeAzimuth;
	if (delta < 0) delta = 360.0 + delta;
	if (delta >= 360.0) delta -= 360.0;
	_homeAzimuth = delta;
	saveConfig();
}
int			Rotator::getHomeStatus()
{
	int status = NEVER_HOMED;

	if (_hasBeenHomed == true) status = HOMED;
	if (_isAtHome == true) status = ATHOME;
	return status;
}
void		Rotator::setParkAzimuth(float newPark)
{
	_parkAzimuth = newPark;
	saveConfig();
}
float		Rotator::getParkAzimuth()
{
	return _parkAzimuth;
}
int			Rotator::getSeekMode()
{
	return _seekMode;
}
void		Rotator::setSeekMode(int mode)
{
	_seekMode = (Seeks)mode;
}
#pragma endregion

#pragma region "Positioning"
long int	Rotator::azimuthToPosition(float azimuth)
{
	long int newPosition;

	newPosition = (float)_stepsPerRotation / (float)360 * azimuth;
	return newPosition;
}
void		Rotator::syncPosition(float newAzimuth)
{
	long int newPosition;

	newPosition = azimuthToPosition(newAzimuth);
	stepper.setCurrentPosition(newPosition);
	saveConfig();
}
long int	Rotator::getPosition()
{
	/// Return change in steps relative to
	/// last sync position
	long position;
	position = stepper.currentPosition();
	if (position > _stepsPerRotation) position -= _stepsPerRotation;
	if (position < 0) position += _stepsPerRotation;
	return position;
}
void		Rotator::setPosition(long int newPosition)
{
	/// Set movement target by step position

	long int currentPosition;

	enableMotor(true);
	currentPosition = getPosition();

	if (newPosition > currentPosition)
	{
		_moveDirection = MOVE_POSITIVE;
	}
	else
	{
		_moveDirection = MOVE_NEGATIVE;
	}
	stepper.moveTo(newPosition);
	return;
}
void		Rotator::moveRelative(long int howFar)
{
	// Use by Home and Calibrate
	// Tells dome to rotate more than 360 degrees
	// from current position. Stopped only by
	// homing or calibrating routine.
	_moveDirection = -1;
	if (howFar > 0) _moveDirection = 1;
	stepper.move(howFar);
}
int			Rotator::getDirection()
{
	return _moveDirection;
}
float		Rotator::getAngularDistance(float fromAngle, float toAngle)
{
	float delta;
	delta = toAngle - fromAngle;
	if (delta == 0) return 0; //  we are already there

	if (delta > 180) delta -= 360;
	if (delta < -180) delta += 360;
	return delta;
}
long int	Rotator::getPositionalDistance(long int fromPosition, long int toPosition)
{
	long int delta;
	delta = toPosition - fromPosition;
	if (delta == 0) return 0; //  we are already there

	if (delta > _stepsPerRotation / 2) delta -= _stepsPerRotation;
	if (delta < -_stepsPerRotation / 2) delta += _stepsPerRotation;
	return delta;

}
void		Rotator::setAzimuth(float newHeading)
{
	// Set movement target by compass azimuth
	float currentHeading, targetPosition;
	float delta;
	float newdelta;
	char stringBuffer[60];

	//FindingHome = false;
	//Calibrating = false;
	currentHeading = getAzimuth();
	delta = getAngularDistance(currentHeading, newHeading) * _stepsPerDegree;
	moveRelative(delta);
	//targetPosition = currentHeading + delta;
	// targetPosition = targetPosition / 360.0 * (float)_stepsPerRotation;
	//setPosition(targetPosition);
}
float		Rotator::getAzimuth()
{
	/* floating point math for get azimuth
	*  prefer floats for accurately placing
	*  the power pickup to charge the shutter
	*  but it introduces significant processing
	*  overhead
	*/
	float azimuth = 0;
	long int currentPosition = 0;

	currentPosition = getPosition();
	if (currentPosition != 0) azimuth = (float)getPosition() / (float)_stepsPerRotation * 360.0;
	//  in case we need to do another step
	//  do a run sequence now
	while (azimuth < 0) azimuth += 360.0;
	while (azimuth >= 360.0) azimuth -= 360.0;

	return azimuth;
}
#pragma endregion

#pragma region "Movement"
void		Rotator::run()
{
	bool stopped;
	long int stepsFromZero;

	stepper.run();
	stopped = !stepper.run();

	buttonCheck();
	if (getSeekMode() != 0) doHomeOrCalibrate();
	if (digitalRead(HOME_PIN) == 1) _isAtHome = false;

	if (stopped)
	{
		_moveDirection = MOVE_NONE;
		_seekMode = HOMING_NONE;

		enableMotor(false);

		stepsFromZero = getPosition();
		if (stepsFromZero < 0)
		{
			while (stepsFromZero < 0) stepsFromZero += _stepsPerRotation;
			stepper.setCurrentPosition(stepsFromZero);
		}
		if (stepsFromZero > _stepsPerRotation)
		{
			while (stepsFromZero> _stepsPerRotation) stepsFromZero -= _stepsPerRotation;
			stepper.setCurrentPosition(stepsFromZero);
		}
		if (_doSync == true)
		{

			syncPosition(_homeAzimuth);
			saveConfig();
			_doSync = false;
		}

	}
}
void		Rotator::stop()
{
	// It takes approximately RunSpeed/3.95 steps to stop
	// Use this to calculate a full step stopping position
	// Actual divisor appears to be 3.997 but this leaves a
	// few extra steps for getting to a full step position.
	long int stopPosition, currentPosition, decelerationSteps;

	if (!stepper.run()) return;

	_seekMode = HOMING_NONE;
	//decelerationSteps = _stepsToStop * _moveDirection;
	//currentPosition = getPosition();
	//stopPosition = currentPosition + decelerationSteps;
	//setPosition(stopPosition);
	stepper.stop();
}
int			Rotator::isMoving()
{
	return stepper.isRunning();
}
#pragma endregion