// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AspNet5ModularApp.Data.EF.Sqlite;
using AspNet5ModularApp.ExtensionB.Data.Abstractions;
using AspNet5ModularApp.ExtensionB.Models;

namespace AspNet5ModularApp.ExtensionB.Data.EF.Sqlite
{
  public class ItemRepository : RepositoryBase<Item>, IItemRepository
  {
    public IEnumerable<Item> All()
    {
      return this.dbSet.OrderBy(i => i.Name);
    }
  }
}