// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using AspNet5ModularApp.Data.Abstractions;
using AspNet5ModularApp.Infrastructure;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet5ModularApp.ExtensionB
{
  public class ExtensionB : IExtension
  {
    public string Name
    {
      get
      {
        return "Extension B";
      }
    }

    public void ConfigureServices(IServiceCollection services)
    {
      Type type = this.GetIStorageImplementationType();

      if (type != null)
      {
        PropertyInfo connectionStringPropertyInfo = type.GetProperty("ConnectionString");

        if (connectionStringPropertyInfo != null)
          connectionStringPropertyInfo.SetValue(null, "Data Source=../db.sqlite");

        PropertyInfo assembliesPropertyInfo = type.GetProperty("Assemblies");

        if (assembliesPropertyInfo != null)
          assembliesPropertyInfo.SetValue(null, ExtensionManager.Assemblies);

        services.AddScoped(typeof(IStorage), type);
      }
    }

    public void RegisterRoutes(IRouteBuilder routeBuilder)
    {
      routeBuilder.MapRoute(name: "Extension B", template: "extension-b", defaults: new { controller = "ExtensionB", action = "Index" });
    }

    private Type GetIStorageImplementationType()
    {
      foreach (Assembly assembly in ExtensionManager.Assemblies.Where(a => a.FullName.Contains("Data")))
        foreach (Type type in assembly.GetTypes())
          if (typeof(IStorage).IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
            return type;

      return null;
    }
  }
}