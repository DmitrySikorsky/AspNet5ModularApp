// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNet5ModularApp.Data.Abstractions;
using AspNet5ModularApp.ExtensionB.Data.Abstractions;
using AspNet5ModularApp.ExtensionB.ViewModels.ExtenstionB;
using Microsoft.AspNet.Mvc;

namespace AspNet5ModularApp.ExtensionB.Controllers
{
  public class ExtensionBController : Controller
  {
    private IStorage storage;

    public ExtensionBController(IStorage storage)
    {
      this.storage = storage;
    }

    public ActionResult Index()
    {
      return this.View(new IndexViewModelBuilder().Build(this.storage.GetRepository<IItemRepository>().All()));
    }
  }
}