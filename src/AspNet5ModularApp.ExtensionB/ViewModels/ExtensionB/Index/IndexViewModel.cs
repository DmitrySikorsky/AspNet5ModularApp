// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using AspNet5ModularApp.ExtensionB.ViewModels.Shared;

namespace AspNet5ModularApp.ExtensionB.ViewModels.ExtenstionB
{
  public class IndexViewModel
  {
    public IEnumerable<ItemViewModel> Items { get; set; }
  }
}