// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using AspNet5ModularApp.Data.Abstractions;
using AspNet5ModularApp.ExtensionB.Models;

namespace AspNet5ModularApp.ExtensionB.Data.Abstractions
{
  public interface IItemRepository : IRepository
  {
    IEnumerable<Item> All();
  }
}