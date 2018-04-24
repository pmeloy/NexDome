A short summary of how the PDM NexDome software works.

First is the communications scheme. The ASCOM driver talks only to a rotation controller, not a shutter. Anything it needs to know about the shutter it asks the rotator which stores information from the shutter.

When the shutter and rotator controllers are powered up they send out a "Hello" message that lets the other know they are there. If the other controller is not present then nothing happens. 

If the shutter starts up first it says hello. If the rotator responds then a bunch of initial data is transmitted (settings and readings that aren't part of the actual "motion" status updates).

If the Rotator starts up first it says hello and, if present, the shutter will transmit the initial information.

If there is no shutter the rotator won't be affected and will just return zeros or blanks when the ASCOM driver asks for shutter information.

When a shutter movement command is issued the shutter will start transmitting status values once per second until motion has stopped.

The Setup button will display one of two forms depending on whether or not you are connected to the rotator already. If not connected it shows a small form where you choose the COM port and can set TRACE. Unless you are hunting down bugs, do NOT turn on trace. It creates a log file in Documents/ASCOM that can get VERY large, VERY quickly. If you are already connected then the PDMDome setup form is displayed where many settings can be changed.

When the ASCOM Setup form is displayed it will first request the most recent values from the rotator so you aren't looking at outdated information.

By default the ASCOM driver does not enable a shutter so when the PDM Dome Setup form is showing you want to tick the Can Set Shutter checkbox to tell ASCOM you have a shutter. This won't take effect until you click OK to close the form but then you can open it right back up again. Same goes for other settings, they don't take effect until OK is clicked. If Cancel is clicked instead any changes you've made are discarded.

While I've done a lot of work on catching and handling user errors I can't gaurantee perfection. If you put in nonsense values then the driver should show a error mark and clicking OK will do nothing (I should probably disable the OK button to make it obvious but that simple concept takes a LOT of code!). If you do manage to get a nonsense value past the error checking then expect an unexpected exception error and probably the driver suddenly disappearing. This might result in the USB port remaining busy even when nothing is connected (Says Unauthorized Exception rather than Busy but that's handled by the guts of ASCOM, not me). If that happens then you need to reboot. Don't forget to post what you were doing when this happened so I can see where I missed in the error checking.

I also realize the way you have to click Setup to get to click Setup is kind of clunky but that's the way ASCOM does things. I'm looking into combining the comport chooser and setup form into a (future) controlbox form to streamline the process a bit.



