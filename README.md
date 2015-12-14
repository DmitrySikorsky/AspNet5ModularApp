# AspNet5ModularApp

This sample shows how to build modular ASP.NET 5 application.

## ExtCore

I have created ExtCore framework you can freely use to build your modular and extendable ASP.NET 5 web applications.
It is enough to add one NuGet dependency to ExtCore.WebApplication to make your web application modular and extendable.

Please take a look at [ExtCore sources](https://github.com/ExtCore/ExtCore) and at the
[sample project](https://github.com/ExtCore/ExtCore-Sample) on GitHub for details.

Feel free to contact me!

## Quick Start

1. Open the solution.
2. Rebuild all.
3. Create folder for extensions (/artifacts/bin/Extensions).
4. Run “copy-extensions” gulp task that will copy all dlls to the extensions folder.
5. Copy System.Reflection.dll and System.Reflection.TypeExtensions.dll from your .dnx folder to the extensions folder too
(see known issues). You may just try to run the application without copying these libs and you will have their names and
versions in the assembly load exception.

## Solution Structure

### AspNet5ModularApp
Main project. Web application. It doesn’t have any controllers or views. Also it doesn’t know anything about how and where data
is stored (it even doesn’t know that data exists). It only knows that we use MVC (but it is not required and can be moved to
extension too) and how to find, load and initialize the extensions.

### AspNet5ModularApp.Infrastructure
Contains interface IExtension (each extension must implement it) and static class ExtensionManager (information about all
available extensions; this class doesn’t know how to find or load or initialize the extensions, only stores them).
This is the only one required project for AspNet5ModularApp to run. You can build your extensions (with controllers, views,
some storage etc) based on this project and it will work. But to have unified way to store data in storage you can use next
3 projects.

### AspNet5ModularApp.Models.Abstractions
Contains interfaces (actually, only one interface) that describe entity.

### AspNet5ModularApp.Data.Abstractions
Contains interfaces IStorageContext, IStorage and IRepository. IStorage is implementation of Unit of Work pattern. Using build-in
ASP.NET 5 dependency injector you can get existing implementation of IStorage in your controllers or view components and then use
method GetRepository to get some specific repository (implementation of IRepository) to work with storage.

### AspNet5ModularApp.Data.EF.Sqlite
Contains classes that implement interfaces from AspNet5ModularApp.Data.Abstractions to work with Sqlite using Entity Framework 7.
Also it contains interface IModelRegistrar that describes how to register models in your extensions to put all of them into the
same database context. StorageContext will search for implementations of this interface and run their RegisterModels method.

## Extension A

It shows how to add views to assembly as resources (and also it shows that the main web application will find this views). Also
it shows how to get and display names of all available extensions.
Using this approach with views added as resources we can’t have views strongly typed if the type is defined inside anything that
the main web application doesn’t have dependency to. In other words we can only use standard types as string or IEnumerable
(https://github.com/aspnet/Mvc/issues/3413).

## Extension B

It shows how to use precompiled strongly typed views with custom view model classes defined inside the extension (main web
application doesn’t have direct dependency to this project). Also it shows how to work with the storage (Sqlite in this case,
but your can easily add implementations for other storages).

## Known Issues

1. Different AspNet5 projects use different versions of System.Xxx, I decided just to put Microsoft.AspNet.Mvc as dependency in all
the projects to have same set of the dependencies in all projects, but this is WRONG. So Microsoft.AspNet.Mvc should be replaced
with for example some version of System.Linq etc, but in this case I got compilation errors because of different versions of System.Xxx
in different projects. Will fix this later and will appreciate any help.
2. Because  the main web application doesn’t have some dependencies the modules need, I had to put for example System.Reflection.dll
and System.Reflection.TypeExtensions.dll to the folder with extensions. I really don’t like it and have to solve it too. 
3. The biggest problem is that I couldn’t find the correct set of assemblies that EntityFramework.Sqlite needs to run (I tried to
copy a lot of them to the extensions folder but with no luck), so I decided just to add EntityFramework.Sqlite as dependency to the
main web application, but I really don’t like it very much, but it works now. So this is what I have to solve too.

## Afterword

I want to shake hands with https://github.com/leo9223/, who helped me to find https://github.com/stuartleeks/ModularVNext. It was
very usful sample for me, I used some ideas from there (the way how to use views stored as resources in assemblies). Also I've used
https://github.com/aspnet/Mvc/tree/dev/test/WebSites/RazorEmbeddedViewsWebSite.