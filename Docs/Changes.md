# Changes #

## April 24, 2018 ##

Re-factored rotator firmware, wrote shutter firmware from scratch, wrote ASCOM driver from scratch (Well, from the ASCOM driver template). Pushed to github and added a release ZIP.

Configurator is dead! The ASCOM driver took over it's duties although its capabilities are missing some of the Configurator functions while it has functions that Configurator didn't have.

## March 28, 2018 ##
Finished including the original shutter code into firmware. Will have a good look once I get the second Leonardo going with it's XBee so it an pretend to be a shutter controller. Also changing all docs to .md files for a much better look.

## March 27, 2018 ##
Configurator looks at controller version to decide if it's talking to the official firmware or not. If it's the official version
it disables all operations that the official firmware can't deal with.

The version format for this project will be 0.Major.Minor.Build
To allow checking for original firmware (V1.1x) I've decided to never use the major version number. The first digit will always
be zero and the real Major version number is in the second position.

Configurator and Firmware must have the same Major and Minor versions to be compartible, build versions don't need to be the same.
