#include "NexDomeRotator.h"
#include <AccelStepper.h>
//#include <EEPROM.h>

// 
// For version 0.1
// 

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

NexDomeRotator::NexDomeRotator()
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

void		NexDomeRotator::saveConfig()
{
	RotatorConfiguration cfg;

	//  zero the structure so currently unused parts
	//  dont end up loaded with random garbage
	memset(&cfg, 0, sizeof(cfg));

	cfg.signature = _signature;
	cfg.stepMode = _stepMode;
	cfg.maxSpeed = _maxSpeed;
	cfg.acceleration = _acceleration;
	cfg.stepsPerRotation = _stepsPerRotation;
	cfg.homeCenter = _homeCenter;
	cfg.stepsToStop = _stepsToStop;
	cfg.reversed = _reversed;
	cfg.homeAzimuth = _homeAzimuth;
	cfg.parkAzimuth = _parkAzimuth;
	cfg.cutoffVolts = _cutoffVolts;

	EEPROM.put(_eepromLocation, cfg);

}
bool		NexDomeRotator::loadConfig()
{
	RotatorConfiguration cfg;
	bool response = true;

	//  zero the structure so currently unused parts
	//  dont end up loaded with random garbage
	memset(&cfg, 0, sizeof(cfg));

	EEPROM.get(_eepromLocation, cfg);
	if (cfg.signature != _signature)
	{
		response = false;
	}
	else
	{
		_stepMode = cfg.stepMode;
		_maxSpeed = cfg.maxSpeed;
		_acceleration = cfg.acceleration;
		_stepsPerRotation = cfg.stepsPerRotation;
		_homeCenter = cfg.homeCenter;
		_stepsToStop = cfg.stepsToStop;
		_reversed = cfg.reversed;
		_homeAzimuth = cfg.homeAzimuth;
		_parkAzimuth = cfg.parkAzimuth;
		_cutoffVolts = cfg.cutoffVolts;


		setStepMode(_stepMode);
		setMaxSpeed(_maxSpeed);
		setAcceleration(_acceleration);
		setStepsPerRotation(_stepsPerRotation);
		setStepsToStop(_stepsToStop);
		setReversed(_reversed);
	}
	return response;
}
void		NexDomeRotator::setDefaults()
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
void		NexDomeRotator::wipeConfig()
{
	RotatorConfiguration cfg;
	memset(&cfg, 0, sizeof(cfg));
	EEPROM.put(_eepromLocation, cfg);
}

int			NexDomeRotator::getControllerVoltage()
{
	int volts;

	volts = analogRead(VOLTAGE_MONITOR_PIN);
	volts = volts / 2;
	volts = volts * 3;
	_controllerVolts = volts;
	return volts;
}
void		NexDomeRotator::setLowVoltageCutoff(int lowVolts)
{
	_cutoffVolts = lowVolts;
}
int			NexDomeRotator::getLowVoltageCutoff()
{
	return _cutoffVolts;
}

void		NexDomeRotator::buttonCheck()
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
bool		NexDomeRotator::isRaining()
{
	return !digitalRead(_rainPin);
}

void		NexDomeRotator::enableMotor(bool newState)
{
	stepper.setEnablePin(newState);
}
float		NexDomeRotator::getMaxSpeed()
{
	return _maxSpeed;
}
void		NexDomeRotator::setMaxSpeed(float newSpeed)
{
	_maxSpeed = newSpeed;
	stepper.setMaxSpeed(newSpeed);
	saveConfig();
}
float		NexDomeRotator::getAcceleration()
{
	return _acceleration;
}
void		NexDomeRotator::setAcceleration(float newAccel)
{
	_acceleration = newAccel;
	stepper.setAcceleration(newAccel);
	saveConfig();
}
bool		NexDomeRotator::getReversed()
{
	return _reversed;
}
void		NexDomeRotator::setReversed(bool isReversed)
{
	_reversed = isReversed;
	stepper.setPinsInverted(isReversed, isReversed, isReversed);
	saveConfig();
}
int			NexDomeRotator::getStepMode()
{
	return _stepMode;
}
void		NexDomeRotator::setStepMode(int newMode)
{
	_stepMode = newMode;
	String msg = "Change steps from " + String(_stepMode) + " to " + String(newMode);
	saveConfig();
}
int			NexDomeRotator::getStepsToStop()
{
	return _stepsToStop;
}
void		NexDomeRotator::setStepsToStop(int steps)
{
	_stepsToStop = steps;
	saveConfig();
}
long int	NexDomeRotator::getStepsPerRotation()
{
	return _stepsPerRotation;
}
void		NexDomeRotator::setStepsPerRotation(long int newCount)
{
	_stepsPerDegree = (float)newCount/ 360.0;
	_stepsPerRotation = newCount;
	saveConfig();
}
int			NexDomeRotator::getHomeCenter()
{
	return _homeCenter;
}
void		NexDomeRotator::setHomeCenter(int steps)
{

	_homeCenter = steps;
	saveConfig();
}
void		NexDomeRotator::startHoming(bool calibrating)
{
	float diff;
	long int distance;

	String msg;
	diff = getAngularDistance(getAzimuth(), getHomeAzimuth());
	_moveDirection = MOVE_POSITIVE;
	if (diff < 1) _moveDirection = MOVE_NEGATIVE;
	if (calibrating == false)
	{
		_seekMode = SEEK_HOME;
	}
	else
	{
		_seekMode = SEEK_START;
		stepper.setCurrentPosition(0);
	}

	distance = (_stepsPerRotation  * _moveDirection * 1.2);
	moveRelative(distance);
}
void		NexDomeRotator::doHomeOrCalibrate()
{
	// Check for home switch hit every 250ms
	static long int nextCheck, homePositionStart, homePositionEnd, currentPosition;
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

	if (_seekMode > SEEK_NONE)
	{
		switch (_seekMode)
		{
		case(SEEK_HOME):
			if (_isAtHome == true)
			{
				homeHit();
				_seekMode = SEEK_NONE;
				stop();
			}
			break;
		case(SEEK_START):
			if (_isAtHome == true && lastSwitchState != _isAtHome)
			{
				homePositionStart = stepper.currentPosition();
				_seekMode = SEEK_MEASURE;
				lastSwitchState = _isAtHome;
			}
			break;
		case(SEEK_MEASURE):
			if (_isAtHome == false && lastSwitchState != _isAtHome)
			{
				homePositionEnd = stepper.currentPosition();
				_seekMode = SEEK_COUNT;
				lastSwitchState = _isAtHome;
				_homeCenter = abs((homePositionEnd - homePositionStart) / 2);
			}
			break;
		case(SEEK_COUNT):
			if (_isAtHome == true && lastSwitchState != _isAtHome)
			{
				//stepsPerRotation = GetPosition() - homePositionStart;
				_seekMode = SEEK_NONE;
				lastSwitchState = false;
				//ConfigSave();
				//HomeHit();
				currentPosition = stepper.currentPosition() - homePositionStart;
				_stepsPerRotation = abs(currentPosition);
				homeHit();

			}
			break;
		}
	}
}
void		NexDomeRotator::homeHit()
{
	long int decelerationSteps;
	 _seekMode= SEEK_NONE;
	_hasBeenHomed = true;
	//if (_homeCenter > 0 && _homeCenter > _stepsToStop)
	//{
	//	decelerationSteps = _homeCenter;
	//}
	//else
	//{
	//	decelerationSteps = _stepsToStop;
	//}
	//decelerationSteps *= _moveDirection;
	//setPosition(getPosition() + decelerationSteps);
	
	_doSync = true;
	stop();
}
void		NexDomeRotator::syncPosition(float newAzimuth)
{
	long int newPosition;

	newPosition = azimuthToPosition(newAzimuth);
	stepper.setCurrentPosition(newPosition);
	saveConfig();
}

long int	NexDomeRotator::getPosition()
{
	/// Return change in steps relative to
	/// last sync position
	long position;
	position = stepper.currentPosition();
	if (position > _stepsPerRotation) position -= _stepsPerRotation;
	if (position < 0) position += _stepsPerRotation;
	return position;
}
void		NexDomeRotator::setPosition(long int newPosition)
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
void		NexDomeRotator::moveRelative(long int howFar)
{
	// Use by Home and Calibrate
	// Tells dome to rotate more than 360 degrees
	// from current position. Stopped only by
	// homing or calibrating routine.
	_moveDirection = -1;
	if (howFar > 0) _moveDirection = 1;
	stepper.move(howFar);
}
int			NexDomeRotator::getDirection()
{
	return _moveDirection;
}

float		NexDomeRotator::getAngularDistance(float fromAngle, float toAngle)
{
	float delta;
	delta = toAngle - fromAngle;
	if (delta == 0) return 0; //  we are already there

	if (delta > 180) delta -= 360;
	if (delta < -180) delta += 360;
	return delta;
}
long int	NexDomeRotator::getPositionalDistance(long int fromPosition, long int toPosition)
{
	long int delta;
	delta = toPosition - fromPosition;
	if (delta == 0) return 0; //  we are already there

	if (delta > _stepsPerRotation/2) delta -= _stepsPerRotation;
	if (delta < -_stepsPerRotation/2) delta += _stepsPerRotation;
	return delta;

}

long int	NexDomeRotator::azimuthToPosition(float azimuth)
{
	long int newPosition;

	newPosition = (float)_stepsPerRotation / (float)360 * azimuth;
	return newPosition;
}
void		NexDomeRotator::setAzimuth(float newHeading)
{
	// Set movement target by compass azimuth
	float currentHeading,targetPosition;
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
float		NexDomeRotator::getAzimuth()
{
	/* floating point math for get azimuth
	*  prefer floats for accurately placing
	*  the power pickup to charge the shutter
	*  but it introduces significant processing
	*  overhead
	*/
	float azimuth = 0;
	long int currentPosition=0;

	currentPosition = getPosition();
	if (currentPosition !=0) azimuth = (float)getPosition() / (float)_stepsPerRotation * 360.0;
	//  in case we need to do another step
	//  do a run sequence now
	while (azimuth < 0) azimuth += 360.0;
	while (azimuth >= 360.0) azimuth -= 360.0;

	return azimuth;
}
void		NexDomeRotator::setHomeAzimuth(float newHome)
{
	_homeAzimuth = newHome;
	saveConfig();
}
float		NexDomeRotator::getHomeAzimuth()
{
	return _homeAzimuth;
}
void		NexDomeRotator::syncHome(float newAzimuth)
{
	float delta, currentAzimuth;

	delta = getAngularDistance(getAzimuth(), newAzimuth);
	delta = delta + _homeAzimuth;
	if (delta < 0) delta = 360.0 + delta;
	if (delta >= 360.0) delta -= 360.0;
	_homeAzimuth = delta;
	saveConfig();
}
int			NexDomeRotator::getHomeStatus() 
{
	int status=NEVER_HOMED;

	if (_hasBeenHomed == true) status = HOMED;
	if (_isAtHome == true) status = ATHOME;
	return status;
}

void		NexDomeRotator::setParkAzimuth(float newPark)
{
	_parkAzimuth = newPark;
	saveConfig();
}
float		NexDomeRotator::getParkAzimuth()
{
	return _parkAzimuth;
}

void		NexDomeRotator::run()
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
		_seekMode = SEEK_NONE;

		enableMotor(false);

		stepsFromZero = getPosition();
		if (stepsFromZero < 0)
		{
			while (stepsFromZero < 0) stepsFromZero += _stepsPerRotation;
			stepper.setCurrentPosition(stepsFromZero);
		}
		if (stepsFromZero > _stepsPerRotation)
		{
			while(stepsFromZero> _stepsPerRotation) stepsFromZero -= _stepsPerRotation;
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
void		NexDomeRotator::stop()
{
	// It takes approximately RunSpeed/3.95 steps to stop
	// Use this to calculate a full step stopping position
	// Actual divisor appears to be 3.997 but this leaves a
	// few extra steps for getting to a full step position.
	long int stopPosition, currentPosition, decelerationSteps;

	if (!stepper.run()) return;

	_seekMode = SEEK_NONE;
	//decelerationSteps = _stepsToStop * _moveDirection;
	//currentPosition = getPosition();
	//stopPosition = currentPosition + decelerationSteps;
	//setPosition(stopPosition);
	stepper.stop();
}

int			NexDomeRotator::getSeekMode()
{
	return _seekMode;
}
void		NexDomeRotator::setSeekMode(int mode)
{
	_seekMode = (Seeks)mode;
}
int			NexDomeRotator::isMoving()
{
	return stepper.isRunning();
}
