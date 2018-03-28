# Unofficial NexDome software project #
NOTE: Master branch only confirmed to work with Rotator kit, not the shutter kit. Current branch is to complete shutter support, publish date unknown.

## First release March 18. 2018 ##
The aim of this project is to provide three pieces of software that are required to operate a NexDome personal observatory under the ASCOM Platform and will consist of:

- Firmware  - written in C++ for the Arduino Leonardo
- Configurator - written in C#
- ASCOM driver - Haven't start on this yet and may just improve the existing Visual Basic one rather than re-invent the wheel.

## Prerequisites ##
Firmware - Either Arduino IDE or Visual Studio with Visual Micro's Arduino add-on. 
(http://www.visualmicro.com/page/Arduino-Visual-Studio-Downloads.aspx).

Configurator - Visual Studio 2015+ with C#

Driver: Lots of patience, it'll be a while before I get started on that!

## Installing ##

#### From Source ####
Sorry but far too much to explain. If you don't know how to do this already then grab the binary release from the releases tab.

#### From Release Binary ####
Unzip wherever you like.

The files inside the firmware folder have to stay together. Load the .ino up into the Arduino IDE or Visual Studio with the Arduino add-in and send to the controller.

Configurator.exe - just run it. It will write a settings file (the kind built into VStudio applications) so you may need write permissions on the folder. You could run it as administrator but that's just not a good idea for anything you download from the net!

## Authors ##
Pat Meloy

## Credits ##
Grozzie2 for the source code I built upon https://github.com/grozzie2/NexDome

## License ##
GPL3

