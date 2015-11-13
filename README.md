# Cimbalino Toolkit [![Build status](https://ci.appveyor.com/api/projects/status/0p6a4efon0vjq8pg?svg=true)](https://ci.appveyor.com/project/Cimbalino/cimbalino-toolkit "Build Status")

![Cimbalino Toolkit](https://github.com/Cimbalino/Cimbalino-Toolkit/raw/master/Cimbalino.Toolkit.png "Cimbalino Toolkit")

Cimbalino Toolkit is a set of useful and powerful tools that will help you build your Windows Platform applications.

The toolkit is fully compatible with:

* Windows Phone Silverlight 8.0 and 8.1 apps (WP8)
* Windows Phone 8.1 apps (WPA81)
* Windows Store 8.1 apps (Win81)
* Windows 10 UWP apps (Universal Windows Platform)

**Note:** Due to changes in the way NuGet works, if you use Cimbalino Toolkit in your Windows 10 UWP (Universal Windows Platform) apps, you will have to manually add the Behaviors SDK!

## NuGet packages ![Latest stable version](https://img.shields.io/nuget/v/Cimbalino.Toolkit.svg?style=flat "Latest stable version")  ![Latest pre-release version](https://img.shields.io/nuget/vpre/Cimbalino.Toolkit.svg?style=flat "Latest pre-release version")

* [Cimbalino.Toolkit.Core](https://www.nuget.org/packages/Cimbalino.Toolkit.Core) - The PCL portion of the toolkit (compatible with background agents)
* [Cimbalino.Toolkit](https://www.nuget.org/packages/Cimbalino.Toolkit) - The main component of the toolkit

## FAQ

### Why do I keep getting NotImplementedExceptions when calling methods from the PCL library?

The toolkit uses the ["Bait and Switch PCL trick"](http://log.paulbetts.org/the-bait-and-switch-pcl-trick/) from Paul Betts to properly support platform implementations, so please **use NuGet to add the packages to ALL your projects and don't add assemblies manually!**

### What about Windows Phone 7.x support?

The Cimbalino Toolkit does not support Windows Phone 7.x, but you can still use the [Cimbalino Windows Phone Toolkit](https://github.com/Cimbalino/Cimbalino-Phone-Toolkit) for that!

### Are there any plans to support other platforms?

Yes, there are some plans in the making, but that will still take some time... :) 

## License

See the [LICENSE.txt](https://github.com/Cimbalino/Cimbalino-Toolkit/raw/master/LICENSE.txt) file for details.

## More information

* [Homepage](http://cimbalino.org)
* [Documentation](http://cimbalino.org/help)
* [@CimbalinoWP (Twitter)](http://twitter.com/CimbalinoWP)

## Acknowledgments

* [Paulo Morgado](https://twitter.com/PauloMorgado)
* [Scott Lovegrove](https://twitter.com/scottisafool)
* [Sara Silva](https://twitter.com/saramgsilva)
* [Jeff Wilcox](https://twitter.com/jeffwilcox)
* All developers that use this toolkit in their apps! :)

## Sponsors

* [JetBrains ReSharper](http://www.jetbrains.com/resharper) - The best C# & VB.NET refactoring plugin for Visual Studio!