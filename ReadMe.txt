# Unofficial NexDome software project #

## Second release April 23, 2018 ##
Now contains all three pieces of software but is in no way compatible with any official NexDome software, firmware or ASCOM driver. 

## First release March 18. 2018 ##
The aim of this project is to provide three pieces of software that are required to operate a NexDome personal observatory under the ASCOM Platform and will consist of:

- PDM Rotator written in C++ for the Arduino Leonardo
- PDM Shutter written in C++ for the Arduino Leonardo
- PDM Dome ASCOM driver for Rotator and Shutter in C#

## Prerequisites ##
Rotator and Shutter - Either Arduino IDE or Visual Studio with Visual Micro's Arduino add-on. 
(http://www.visualmicro.com/page/Arduino-Visual-Studio-Downloads.aspx).

PDM Dome - Visual Studio 2015+ with C#

## Installing ##

#### From Source ####
Sorry but far too much to explain. If you don't know how to do this already then grab the binary release from the releases tab.

#### From Release Binary ####
Click on releases to find the binary downloads
![Releases Tab](/Docs/img/ReleasePic.png)

The ASCOM driver has a basic installer (default ASCOM provided) while the Arduio files have to be copied to whereever you want them. The Arduino IDE usually creates an Arduino directory in your documents folder which is a good place.

Arduino programs must have the same name as they directory they are in so it's easiest to just copy then PDMRotator and PDMShutter directories rather than the individual files.

To upload the firmwares, connect a USB cable to the unit then double click the .ino (not the .h - those automagically load). Set your board to Leonardo and choose the correct COM port (should say Arduino Leonardo(COMx). Then hit upload and a few seconds later it'll be finished.

Still to do:

- Implement sleep mode for the shutter radio
- Implement auto-close on the shutter after X minutes of not hearing from the Rotator.
- Have Shutter poll the rotator for rain sensor status (right now rotator broadcasts the rain status which may not be a good idea later when the shutter is trying to sleep.

## Authors ##
Pat Meloy

## Credits ##
Grozzie2 for the source code I built upon https://github.com/grozzie2/NexDome

## License ##
GPL3

