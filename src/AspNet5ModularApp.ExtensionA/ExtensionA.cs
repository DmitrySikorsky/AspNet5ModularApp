// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNet5ModularApp.Infrastructure;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet5ModularApp.ExtensionA
{
  public class ExtensionA : IExtension
  {
    public string Name
    {
      get
      {
        return "Extension A";
      }
    }

    public void ConfigureServices(IServiceCollection services)
    {
    }

    public void RegisterRoutes(IRouteBuilder routeBuilder)
    {
      routeBuilder.MapRoute(name: "Extension A", template: "extension-a", defaults: new { controller = "ExtensionA", action = "Index" });
    }
  }
}