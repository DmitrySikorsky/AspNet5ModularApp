// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNet5ModularApp.ExtensionB.Models;

namespace AspNet5ModularApp.ExtensionB.ViewModels.Shared
{
  public class ItemViewModelBuilder
  {
    public ItemViewModel Build(Item item)
    {
      return new ItemViewModel()
      {
        Name = item.Name
      };
    }
  }
}