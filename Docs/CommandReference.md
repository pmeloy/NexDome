These are the commands sent to the controller by whatever you're using to control it. They can just be typed in manually from the Arduino IDE or Configurator serial area as well.

_Italics_ means optional.

Original Firmware Commands

 Cmd     | Description                       | Response      | Tested | Comment                       
-------- | --------------------------------- | ------------- | ------ |-----
a        | Abort movement/Stop dome          | A             | Y      |
b        | Get Shutter Position              | B int         | N      |
c        | Start calibration routine         | C or E        | Y      | E if not at home position           
d        | Open shutter                      | D or E        | N      | E means rain sensor has aborted     
e        | Close shutter                     | D             | N      |
f float  | Set shutter position              | F             | N      | 0 to 100%? Verify this              
g float  | Goto supplied azimuth             | G or E        | Y      | 0.00 to 359.99 degrees, E=invalid   
h        | Home the dome                     | H             | Y      |                                     
i        | Get home azimuth                  | I float       | Y      |                                     
j float  | Set home azimuth                  | I float       | Y      | 0.00 to 359.99 degrees              
k _int_  | Get battery voltages, set cutoff  | K int int int | P      | Main, Shutter, Low voltage cutout   
l float  | Set park azimuth                  | N float       | Y      | 0.00359.99 degrees                  
m        | Motion status                     | M int         | Y      | 0-3                                 
n        | Get park azimuth                  | N float       | Y      |                                     
o        | Get last heading error            | O float       | Y      |                                     
p        | Get stepper position              | P long        | Y      |                                     
q        | Get current azimuth               | Q float       | Y      |                                     
r _long_ | Get or Set shutter sleep time     | R long        | N      |                                     
s float  | Sync to supplied azimuth          | S float or E  | Y      | 0.00359.99 degrees, E if invalid    
t        | Get steps per rotation            | T long        | Y      |                                     
u        | Get shutter status                | U int         | N      | Rain status removed for now         
v        | Get firmware version              | V string      | P      | Major Minor _Shutter_
w        | Restart wireless                  | W             | Y      |                                     
y _int_  | Get or set reversed motion status | Y             | Y      | 0 normal, 1 reversed                
x        | Wake shutter                      | X             | N      |                                     
z        | Home status                       | Z int         | Y      | 1 not homed,0 not at home,1 at home 

New Firmware Commands

 Cmd       | Description                     | Response      | Tested | Comment                       
---------- | ------------------------------- | ------------- | ------ |-----
\[ long    | Relative move by step count     |               | Y      | How many steps +/-, from position 
\# _float_ | Get/Set maximum speed           |               | Y      | Only set at startup for now        
^          | Get motor direction             | ^ int         | Y      | -1 negative, 1 positive            
$ _int_    | Get/Set number of microsteps    | $ int         | Y      | Must match dip switch settings!!    
\* _float_ | Get/Set acceleration            | * float       | Y      | Around 8k good at 8 microsteps      
\          | Get seek mode                   | \ int         | Y      | See seekmodes                       
?          | Load config from EEPROM         | ?             | Y      | May be deprecated                   
/          | Save config to EEPROM           | /             | Y      | May be deprecated                   

