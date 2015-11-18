// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspNet5ModularApp.Infrastructure;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace AspNet5ModularApp
{
  public class Startup
  {
    private string applicationBasePath;
    private IAssemblyLoaderContainer assemblyLoaderContainer;
    private IAssemblyLoadContextAccessor assemblyLoadContextAccessor;

    public Startup(IApplicationEnvironment applicationEnvironment, IAssemblyLoaderContainer assemblyLoaderContainer, IAssemblyLoadContextAccessor assemblyLoadContextAccessor)
    {
      this.applicationBasePath = applicationEnvironment.ApplicationBasePath;
      this.assemblyLoaderContainer = assemblyLoaderContainer;
      this.assemblyLoadContextAccessor = assemblyLoadContextAccessor;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      IEnumerable<Assembly> assemblies = AssemblyManager.LoadAssemblies(
        this.applicationBasePath.Substring(0, this.applicationBasePath.LastIndexOf("src")) + "artifacts\\bin\\Extensions",
        this.assemblyLoaderContainer,
        this.assemblyLoadContextAccessor
      );

      ExtensionManager.SetAssemblies(assemblies);
      services.AddMvc()
        .AddPrecompiledRazorViews(ExtensionManager.Assemblies.ToArray())
        .AddRazorOptions(razorOptions => { razorOptions.FileProvider = this.GetFileProvider(assemblies, this.applicationBasePath); });

      services.AddTransient<DefaultAssemblyProvider>();
      services.AddTransient<IAssemblyProvider, ExtensionAssemblyProvider>();

      foreach (IExtension extension in ExtensionManager.Extensions)
        extension.ConfigureServices(services);
    }

    public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
    {
      if (hostingEnvironment.IsEnvironment("Development"))
      {
        applicationBuilder.UseBrowserLink();
        applicationBuilder.UseDeveloperExceptionPage();
        applicationBuilder.UseDatabaseErrorPage();
      }

      else
      {
      }

      applicationBuilder.UseStaticFiles();
      applicationBuilder.UseMvc(routeBuilder =>
        {
          foreach (IExtension extension in ExtensionManager.Extensions)
            extension.RegisterRoutes(routeBuilder);
        }
      );
    }

    public IFileProvider GetFileProvider(IEnumerable<Assembly> assemblies, string path)
    {
      IEnumerable<IFileProvider> fileProviders = new IFileProvider[] { new PhysicalFileProvider(path) };

      return new CompositeFileProvider(
        fileProviders.Concat(
          assemblies.Select(a => new EmbeddedFileProvider(a, a.GetName().Name))
        )
      );
    }
  }
}