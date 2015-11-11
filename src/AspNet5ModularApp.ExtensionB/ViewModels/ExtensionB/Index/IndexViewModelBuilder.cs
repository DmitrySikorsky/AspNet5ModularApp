// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AspNet5ModularApp.ExtensionB.Models;
using AspNet5ModularApp.ExtensionB.ViewModels.Shared;

namespace AspNet5ModularApp.ExtensionB.ViewModels.ExtenstionB
{
  public class IndexViewModelBuilder
  {
    public IndexViewModel Build(IEnumerable<Item> items)
    {
      return new IndexViewModel()
      {
        Items = items.Select(i => new ItemViewModelBuilder().Build(i))
      };
    }
  }
}