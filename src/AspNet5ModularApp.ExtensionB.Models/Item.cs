﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using AspNet5ModularApp.Models.Abstractions;

namespace AspNet5ModularApp.ExtensionB.Models
{
  public class Item : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}