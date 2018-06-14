 When you connect software together to run an observatory there are at least three pieces to the puzzle. A telescope driver, a dome driver, and an application to coordinate the two.

The drivers jobs are to make information available to the application and to translate commands from the application into actions by the scope and dome.

Drivers have no awareness of other devices or even the application and cannot initiate communications with any other software, they can only respond to commands or requests for information from the application.

An application example would be POTH Scope-Dome hub or Sequence Generator Pro. The application will be aware of all the hardware you set up inside and can command the devices or ask them for information.

When a scope and dome are slaved together neither the scope nor the dome know anything about one another, slaving is entirely handled inside the client application. In reality it is the application asking the scope where it is pointing then performing calculations to figure out where the dome should be pointing and commanding the dome to point there. The drivers themselves have no idea what slaving is or whether or not it's active.

This works well as long as the application is commanding the scope to move because then the application knows where the scope is (or will be) pointing at all times. If you use the scope hand controller to move the telescope it's a different story!

When a hand control is used the application does not know the telescope has moved or is moving and the telescope driver cannot tell the application that something is happening. The application has to ask. It's entirely up to the application when and how often it checks with the drivers to see what's happening with its devices. If it doesn't ask for 30 seconds then the scope (or dome) commanded by hand-controls will keep changing while the application knows nothing about it for 30 seconds.

A telescope or dome driver may include a handy form for moving the scope or dome but using a driver supplied form is the same as using the hand-control in that the information about that move is known only to the driver and it's hardware and not the application. Until the application polls the driver it knows nothing.

An application may (should) have it's own controls form for manually moving the scope and dome. If movements are initiated from this form then the application knows what is going to happen before the drivers even get commanded so it can respond immediately to movement commands.

As an example, the Celestron Telescope driver opens a small control form with four arrows. Using that form moves the scope but your application doesn't know about. Same goes with the ASCOM .NET Telescope and Dome simulator control forms. The application is not aware of commands from these forms until it polls the drivers for information.

I've found out that POTH (and perhaps SGP) can take tens of seconds to find out about movements that originate from hand-controls and driver forms and sometimes they never know about them at all.

So if you're testing out slaving using a hand-control or driver control form to move things, don't expect it to work well or even to always respond. Use only the application controls to command the scope and the dome should always respond quickly.
