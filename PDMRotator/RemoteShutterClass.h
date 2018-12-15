/*
* PDM NexDome Rotation kit firmware. NOT compatible with original NexDome ASCOM driver.
*
* Copyright (c) 2018 Patrick Meloy
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

#pragma region Defines
#if defined(ARDUINO) && ARDUINO >= 100
#include "arduino.h"
#else
#include "WProgram.h"
#endif
#pragma endregion


class RemoteShutterClass
{
public:
	// Todo: remove this if state becomes a string
	enum ShutterStates { OPEN, CLOSED, OPENING, CLOSING, ERROR };

	// TODO: See if these can all be strings
	// These have to be real data for communications reasos
	String state = "4"; // Cause we don't know until the shutter tells us.

	// These aren't used by Rotator so why bother converting them to numeric values?
	String	acceleration = "";
	String	elevation = "";
	String	homedStatus = "";
	String	OpenError = "";
	String	position ="";
	String	speed = "";
	String	reversed = "";
	String	sleepSettings ="";
	String	stepsPerStroke = "";
	// ASCOM checks version and if it's blank then shutter doesn't exist
	String	version = "";
	String	volts = "";
	String voltsClose = "";

	RemoteShutterClass();
	// void SetState(int);
};

RemoteShutterClass::RemoteShutterClass()
{

}
//void RemoteShutterClass::SetState(int newState)
//{
//	state = (ShutterStates)newState;
//}
