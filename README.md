Oculus Hardware Specs Patcher
=============================

The Oculus Rift software is very strict when it comes to its hardware recommendations. If you try to run the Oculus Rift on a PC with components that are not on Oculus' whitelist,
you will get a message telling you that your PC does not meet the recommended hardware specifications and that your VR experience may suffer as a result.
Most annoyingly, this message will always appear on top of your Oculus Home screen in VR and cannot be dismissed.

This patcher tool can fix that. It patches one line of code in the Oculus Home app, to make it believe you are always running with the recommended hardware specifications.
The result: no more annoying warning message in VR.

Requirements
------------

  * Oculus software with Oculus Home installed
  * .NET Framework 4.0 or higher
  
Usage
-----

  * Take off your Oculus Rift headset, and make sure the Oculus application is closed.
  * Run the included executable (OculusSpecsPatcher.exe). If Oculus is installed in C:\Program Files, then run the executable as administrator (right click -> Run As Administrator).
  * Check whether the patcher correctly identified the installation directory of Oculus Home. Browse for a different location if desired.
  * Click on the Patch button to start patching. Check the log to see if the process finished with an "All done!" message.
  * If an error occurred, make sure you selected the right installation directory of Oculus Home and that you are running the patcher with the right credentials.

Disclaimer
----------

Use this program at your own risk. I will not be held responsible if you damage your Oculus installation or other parts of your system. If something breaks, you get to keep both pieces.
