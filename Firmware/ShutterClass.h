#pragma once

#include <EEPROM.h>

#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif

const int SHUTTER_STATE_NOT_CONNECTED = 0;
const int SHUTTER_STATE_OPEN = 1;
const int SHUTTER_STATE_OPENING = 2;
const int SHUTTER_STATE_CLOSED = 3;
const int SHUTTER_STATE_CLOSING = 4;
const int SHUTTER_STATE_UNKNOWN = 5;
const int SHUTTER_VERSION_LENGTH = 5;

class Shutter
{
protected:


public:

	bool		isAlive = false;
	bool		isConfiguring = false;
	int			configState = 0;
};
