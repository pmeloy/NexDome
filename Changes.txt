Changes

March 27, 2018
--------------
Configurator looks at controller version to decide if it's talking to the official firmware or not. If it's the official version
it disables all operations that the official firmware can't deal with.

The version format for this project will be 0.Major.Minor.Build
To allow checking for original firmware (V1.1x) I've decided to never use the major version number. The first digit will always
be zero and the real Major version number is in the second position.

Configurator and Firmware must have the same Major and Minor versions to be compartible, build versions don't need to be the same.
