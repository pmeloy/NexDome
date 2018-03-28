# Unofficial NexDome software project #
------------------------------------

NOTE: Master branch only confirmed to work with Rotator kit, not the shutter kit. Current branch is to complete shutter support, publish date unknown.

## First release March 18. 2018 ##
==================================
The aim of this project is to provide three pieces of software that are required to operate a NexDome personal observatory under the ASCOM Platform and will consist of:

- Firmware  - written in C++ for the Arduino Leonardo
- Configurator - written in C#
- ASCOM driver - Haven't start on this yet and may just improve the existing Visual Basic one rather than re-invent the wheel.

## Prerequisites ##
--------------
Firmware - Either Arduino IDE or Visual Studio with Visual Micro's Arduino add-on 
(http://www.visualmicro.com/page/Arduino-Visual-Studio-Downloads.aspx).

Configurator - Visual Studio 2015+ with C#

Driver: Lots of patience, it'll be a while before I get started on that!

## Installing ##
----------
Firmware - You don't need Visual Studio for this, the Arduino IDE works perfectly fine.

Three files are required: Firmware.ino, RotatorClass.h and RotatorClass.cpp the Arduino IDE will insist on putting the .ino in its own directory, just copy the other two into the same directory afterward. You will get errors if they are not in the same directory.

Configurator - Either compile from the source project yourself or grab the release binary. As long as you have .net installed it should just run. Configurator doesn't use the registry or write any files so permissions shouldn't be a problem.

## Authors ##
--------
Pat Meloy

## Credits ##
-------
Grozzie2 for the source code I built upon https://github.com/grozzie2/NexDome

## License ##
-------
GPL3

