// Rotator.h version 0.01

#ifndef _ROTATOR_h
#define _ROTATOR_h
#include <EEPROM.h>
//#include <AccelStepper.h>
#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif

#define usb Serial
#define wireless Serial1
#define VOLTAGE_MONITOR_PIN A0

enum Seeks
{
	HOMING_NONE, // Not homing or calibrating
	HOMING_HOME, // Homing
	CALIBRATION_START, // Calibrate finding home before calibrating
	CALIBRATION_MOVEOFF, // Ignore home until we've moved off while measuring the dome.
	CALIBRATION_MEASURE // Measuring dome until home hit again.
};

class Rotator
{

protected:

	typedef struct RotatorConfiguration
	{
		int			signature;
		int			stepMode;
		float		maxSpeed;
		long int	acceleration;
		long int	stepsPerRotation;
		long int	homeCenter;
		long int	stepsToStop;
		bool		reversed;
		float		homeAzimuth;
		float		parkAzimuth;
		int			cutoffVolts;
	} RotatorConfig;

	const int		_signature = 8051;
	const int		_eepromLocation = 10;
	const long int	_STEPSFORROTATION = 55100;


	// Stepper motor DongZheng Motor Co.
	// 2.5V 2.8A 1:15 1.8D/step
	// Model 56JXS300K15G
	// 3000 steps per rev, 6912mm travel
	const float microStepsPerRev = 1600;
	const float gearCircumference = 379; // in millimeters
	int			_homePin;
	int			_enablePin;
	int			_directionPin;
	int			_stepPin;
	float		_maxSpeed;
	long int	_acceleration;
	int			_stepMode = 1;

	// Inputs
	int			_btnCCWPin;
	int			_btnCWpin;
	int			_rainPin;

	// Rotator properties
	float		_homeAzimuth = 0;
	float		_parkAzimuth = 0;
	int			_homeCenter = 0;
	RotatorConfig cfg;

	// Rotator
	bool		_isAtHome;
	bool		_hasBeenHomed;
	enum Seeks	_seekMode;
	bool		_doSync;
	bool		_reversed;
	long int	_stepsToStop;
	long int	_stepsPerRotation;
	float		_stepsPerDegree;

	// movement
	const int	MOVE_NEGATIVE = -1;
	const int	MOVE_NONE = 0;
	const int	MOVE_POSITIVE = 1;
	int			_moveDirection;

	// Power values
	int			_controllerVolts;
	int			_cutoffVolts;

	void		enableMotor(bool);
	float		getAngularDistance(float fromAngle, float toAngle);
	void		homeHit();
public:

	Rotator();
	bool		isRaining();
	void		stop();
	void		run();
	void		buttonCheck();

	void		saveConfig();
	bool		loadConfig();
	void		setDefaults();
	void		wipeConfig();

	long int	getPosition();
	void		setPosition(long int);
	long int	getPositionalDistance(long int, long int);
	void		moveRelative(long int steps);
	void		syncPosition(float);

	int			getSeekMode();
	void		setSeekMode(int);
	int			isMoving();
	int			getDirection();
	int			getStepMode();
	void		setStepMode(int);
	float		getMaxSpeed();
	void		setMaxSpeed(float);
	float		getAcceleration();
	void		setAcceleration(float);
	long int	getStepsPerRotation();
	void		setStepsPerRotation(long int);
	void		setReversed(bool reversed);
	bool		getReversed();

	void		setAzimuth(float);

	void		syncHome(float);
	float		getAzimuth();
	void		setHomeAzimuth(float);
	float		getHomeAzimuth();
	int			getHomeStatus();
	void		startHoming(bool);
	void		doHomeOrCalibrate();

	void		setParkAzimuth(float);
	float		getParkAzimuth();
	long int	azimuthToPosition(float);

	int			getControllerVoltage();
	void		setLowVoltageCutoff(int);
	int			getLowVoltageCutoff();
};

#endif

