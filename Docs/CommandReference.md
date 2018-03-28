These are the commands sent to the controller by whatever you're using to control it. They can just be typed in manually from the Arduino IDE or Configurator serial area as well.

Original Firmware Commands

 Cmd   | Description                       | Response | Tested | Comment                       
------ | --------------------------------- | -------- | ------ |-----
a | Abort movement/Stop dome          | A | Y |
b     | Get Shutter Position              | Bi       | N |
c     | Start calibration routine         | C or E   | Y | E if not at home position           
d     | Open shutter                      | D or E   | N | E means rain sensor has aborted     
e     | Close shutter                     | D        | Y |
f float | Set shutter position              | F        | Y | 0 to 100%? Verify this              
g float   | Goto supplied azimuth             | G or E   | Y | 0.00 to 359.99 degrees, E=invalid   
 h     | Home the dome                     | H        | Y |                                     
 i     | Get home azimuth                  | I f      | Y |                                     
 j float   | Set home azimuth                  | I f      | Y | 0.00 to 359.99 degrees              
k <int> | Get battery voltages, set cutoff  | Ki i i   | P | Main, Shutter, Low voltage cutout   
l float   | Set park azimuth                  | N f      | Y | 0.00359.99 degrees                  
 m     | Motion status                     | Mi       | Y | 0-3                                 
 n     | Get park azimuth                  | N f      | Y |                                     
 o     | Get last heading error            | O f      | Y |                                     
 p     | Get stepper position              | P l      | Y |                                     
 q     | Get current azimuth               | Q f      | Y |                                     
r <long> | Get or Set shutter sleep time     | R l      | Y |                                     
 s float   | Sync to supplied azimuth          | S f or E | Y | 0.00359.99 degrees, E if invalid    
 t     | Get steps per rotation            | T l      | Y |                                     
 u     | Get shutter status                | U i      | N | Rain status removed for now         
 v     | Get firmware version              | V s      | Y | Major Minor                         
 w     | Restart wireless                  | W        | N |                                     
 y <int> | Get or set reversed motion status | Y        | Y | 0 normal, 1 reversed                
 x     | Wake shutter                      | X        | N |                                     
 z     | Home status                       | Z i      | Y | 1 not homed,0 not at home,1 at home 
