/*	Serial Commands
 Values in <> are optional
 Some commands are listed for both because the results differ if shutter is installed
 Y = Tested, P = Partially Tested, N = Not Tested (P and N are because I don't have that equipment)
 ASCOM serial commands as per original firmware
+------------------------------------------------------------------------------------------------+
| Original Firmware Commands                                                                     |
+------------------------------------------------------------------------------------------------+
| Char       Description                        Response   Tested  Comment                       |
+-------+-----------------------------------+----------+---+-------------------------------------+
| a     | Abort movement/Stop dome          | A        | Y |                                     |
| b     | Get Shutter Position              | Bi       | N |                                     |
| c     | Start calibration routine         | C or E   | Y | E if not at home position           |
| d     | Open shutter                      | D or E   | N | E means rain sensor has aborted     |
| e     | Close shutter                     | D        | Y |                                     |
| f f   | Set shutter position              | F        | Y | 0 to 100%? Verify this              |
| g f   | Goto supplied azimuth             | G or E   | Y | 0.00 to 359.99 degrees, E=invalid   |
| h     | Home the dome                     | H        | Y |                                     |
| i     | Get home azimuth                  | I f      | Y |                                     |
| j f   | Set home azimuth                  | I f      | Y | 0.00 to 359.99 degrees              |
| k <i> | Get battery voltages, set cutoff  | Ki i i   | P | Main, Shutter, Low voltage cutout   |
| l f   | Set park azimuth                  | N f      | Y | 0.00359.99 degrees                  |
| m     | Motion status                     | Mi       | Y | 0-3                                 |
| n     | Get park azimuth                  | N f      | Y |                                     |
| o     | Get last heading error            | O f      | Y |                                     |
| p     | Get stepper position              | P l      | Y |                                     |
| q     | Get current azimuth               | Q f      | Y |                                     |
| r <l> | Get or Set shutter sleep time     | R l      | Y |                                     |
| s f   | Sync to supplied azimuth          | S f or E | Y | 0.00359.99 degrees, E if invalid    |
| t     | Get steps per rotation            | T l      | Y |                                     |
| u     | Get shutter status                | U i      | N | Rain status removed for now         |
| v     | Get firmware version              | V s      | Y | Major Minor                         |
| w     | Restart wireless                  | W        | N |                                     |
| y <i> | Get or set reversed motion status | Y        | Y | 0 normal, 1 reversed                |
| x     | Wake shutter                      | X        | N |                                     |
| z     | Home status                       | Z i      | Y | 1 not homed,0 not at home,1 at home |
+-------+-----------------------------------+----------+---+-------------------------------------+

+------------------------------------------------------------------------------------------------+
| New Firmware Commands. All commands from Configurator have % prepended                         |
+------------------------------------------------------------------------------------------------+
| Char   Description                        Response      Tested  Comment                        |
+-------+-----------------------------------+----------+---+-------------------------------------+
| %     | From Configurator                 | none     | Y |                                     |
| [ l   | Relative move by step count       |          | Y | How many steps +/-, from position   |
| # <f> | Get/Set maximum speed             |          | Y | Only set at startup for now         |
| ^     | Get motor direction               | ^i       | Y | -1 negative, 1 positive             |
| $ <i> | Get/Set number of microsteps      | $i       | Y | Must match dip switch settings!!    |
| * <f> | Get/Set acceleration              | * f      | Y | Around 8k good at 8 microsteps      |
| | <l> | Get/Set home center               | l        | Y | Deprecated                          |
| ! <l> | Get/Set Steps to stop             | ! l      | Y | Deprecated                          |
| \     | Get seek mode                     | \i       | Y | See seekmodes                       |
| C     | Comment from firmware             |          | Y |                                     |
| ?     | Load config from EEPROM           | ?        | Y | May be deprecated                   |
| /     | Save config to EEPROM             | /        | Y | May be deprecated                   |
+-------+-----------------------------------+---------------+---+--------------------------------+

Wireless is not function yet. Will tackle that once the rotator portion is done. Work in progress
+------------------------------------------------------------------------------------------------+
|Shutter Commands over wireless (Case is important!)                                             |
+------------------------------------------------------------------------------------------------+
|Char        Description                     Response   Tested Comment                           |
+-------+-----------------------------------+----------+-----+-----------------------------------+
| a     | Abort movement/Stop shutter       | ?        |  N  |                                   |
| c     | Close shutter                     | ?        |  N  |                                   |
| f f   | Set shutter position              | ?        |  N  | 0100%? Clarify with vendor        |
| h l   | Set shutter sleep time            | ?        |  N  |                                   |
| k <i> | Get battery voltages, set cutoff  | ?        |  N  | Main, Shutter, Low voltage cutout |
| r <l> | Get/set shutter hibernate timer   | ?        |  N  | millseconds? Clarify with vendor  |
| o     | Open shutter                      | ?        |  N  |                                   |
| v     | Get firmware versions             | ?        |  N  | Verions Major/Minor               |
| w     | restart wireless                  | ?        |  N  |                                   |
| x     | Wake shutter                      | ?        |  N  |                                   |
+-------+-----------------------------------+----------+-----+-----------------------------------+

*/                                                