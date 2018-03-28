Configurator is a Windows based utility for configuring the NexDome Rotator controller.

This is the new shiny thing when it comes to the NexDome software. Many of the settings that were invisible, never mind editable, can now be seen and easily changed and tested.

Examples of what can be changed:
- Step mode (must match the dip switch settings!)
- Maximum speed
- Acceleration
- Steps per dome rotation (better than auto homing!)
- Home Azimuth
- Park Azimuth

It also includes a simple terminal program so you can send serial commands manually if so desired.

The best part is being able to fine tune the steps per rotation to exactly match your dome. A quicky tutorial!
## Calibration Process ##
 - Home the dome
 - Move dome back so home switch is not active
 - Click Calibrate and wait while it does it's work. Note, it only turns 1.2x the current Steps per Rotation value so don't start 180 degrees away from the home switch.
 - When that is complete mark or otherwise identify the exact position of the dome then click "Full turn". The dome will rotate exactly one less step than the amount specified in Steps per Rotation. If the dome ends up right back at your mark, you're done. It should be pretty close but probably not perfect.
 - If the dome has not rotated far enough, enter a new position into the textbox beside the "Go to Pos" button and then click to move the dome. Experiment until the dome is exactly at your mark then click "Save Settings"
 - The position value wraps around to zero (or max -1) so if you move left the dome a bit shy of your mark, you'll have to wrap the number in your head e.g. If it's at 440799 then you'll have to enter 5 or 100 or whatever works. If you're at 5 and need to go counterclockwise you'll use something like 440699.
 
 #### Near Future ####
 - [x] Add buttons for relative moves
 - [x] Remove the "measure home" process. It seemed like a good idea when the dome was slow and bouncing.
 - [ ] Make STOP button change colours when dome is stopped or moving.
 - [ ] Add Shutter control.
 - [ ] Redo communications as I develop the firmware.
 
 #### Futher down the pipe ####
 - Don't know!
 
