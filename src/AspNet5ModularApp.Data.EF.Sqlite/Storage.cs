﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspNet5ModularApp.Data.Abstractions;

namespace AspNet5ModularApp.Data.EF.Sqlite
{
  public class Storage : IStorage
  {
    public static string ConnectionString { get; set; }
    public static IEnumerable<Assembly> Assemblies { get; set; }

    public StorageContext StorageContext { get; private set; }

    public Storage()
    {
      this.StorageContext = new StorageContext(Storage.ConnectionString, Storage.Assemblies);
      this.StorageContext.Database.EnsureCreated();
    }

    public TRepository GetRepository<TRepository>() where TRepository : IRepository
    {
      foreach (Assembly assembly in Storage.Assemblies.Where(a => a.FullName.Contains("EF.Sqlite")))
      {
        foreach (Type type in assembly.GetTypes())
        {
          if (typeof(TRepository).IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
          {
            TRepository repository = (TRepository)Activator.CreateInstance(type);

            repository.SetStorageContext(this.StorageContext);
            return repository;
          }
        }
      }

      throw new ArgumentException("Implementation of " + typeof(TRepository) + " not found");
    }

    public void Save()
    {
      this.StorageContext.SaveChanges();
    }
  }
}