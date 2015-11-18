// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNet5ModularApp.Data.EF.Sqlite;
using AspNet5ModularApp.ExtensionB.Models;
using Microsoft.Data.Entity;

namespace AspNet5ModularApp.ExtensionB.Data.EF.Sqlite
{
  public class ModelRegistrar : IModelRegistrar
  {
    public void RegisterModels(ModelBuilder modelbuilder)
    {
      modelbuilder.Entity<Item>(etb =>
        {
          etb.HasKey(e => e.Id);
          etb.Property(e => e.Id);
          etb.ForSqliteToTable("Items");
        }
      );
    }
  }
}