// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNet5ModularApp.Data.Abstractions;
using AspNet5ModularApp.Models.Abstractions;
using Microsoft.Data.Entity;

namespace AspNet5ModularApp.Data.EF.Sqlite
{
  public abstract class RepositoryBase<TEntity> : IRepository where TEntity : class, IEntity
  {
    protected StorageContext dbContext;
    protected DbSet<TEntity> dbSet;

    public void SetStorageContext(IStorageContext dbContext)
    {
      this.dbContext = dbContext as StorageContext;
      this.dbSet = this.dbContext.Set<TEntity>();
    }
  }
}