# ![](https://github.com/RealityRipple/Eudemons-Music-Editor/raw/master/Eudemons%20Music%20Editor/Resources/corner.bmp) Eudemons Music Editor
Background music editor for Eudemons Online.

#### Version 1.0.1
> Author: Andrew Sachen  
> Created: July 16, 2012  
> Updated: October 23, 2018  

Language: Visual Basic.NET  
Compiler: Visual Studio 2010  
Framework: Version 4.0+

##### Involved Technologies:
* FreeImage
* [YourCulture](https://yourculture.uk/free-translation-service/)
* INI file manipulation

## Building
This application can be compiled using Visual Studio 2010 or newer, however an Authenticode-based Digital Signature check is integrated into the code to prevent incorrectly-signed or unsigned copies from running. Comment out lines 11-15 of `/Eudemons Music Editor/ApplicationEvents.vb` to disable this signature check before compiling if you wish to build your own copy.

This application is *not* designed to support Mono/Xamarin compilation and may not work on Linux or OS X systems. In particular, there are multiple API calls used by this application: "WinVerifyTrust", "Get/WritePrivateProfileString", "Load/SetCursor", and "SendMessage". The first call is used as part of the Authenticode Digital Signature check mentioned above, the others for functional and visual purposes. There may also be internal code which supports Windows UI-drawing methods specifically and may perform poorly or incorrectly on alternate Operating Systems.

## Documentation
See the [Official Web Site](https://realityripple.com/Software/Applications/Eudemons-Music-Editor/) for documentation on how this program works.

## Download
You can grab the latest release from the [Official Web Site](https://realityripple.com/Software/Applications/Eudemons-Music-Editor/).

## License
This is free and unencumbered software released into the public domain, supported by donations, not advertisements. If you find this software useful, [please support it](https://realityripple.com/donate.php?itm=Eudemons+Music+Editor)!
