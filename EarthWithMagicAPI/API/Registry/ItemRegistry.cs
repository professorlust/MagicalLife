﻿// <copyright file="ItemRegistry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Registry
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using EarthWithMagicAPI.API.Interfaces.Items;

    public static class ItemRegistry
    {

        static ItemRegistry()
        {
            Assembly itemAssembly = Assembly.Load(new AssemblyName("EarthMagicItems"));
            Type interfaceType = typeof(IItem);

            foreach (Type item in itemAssembly.GetTypes())
            {
                if (interfaceType.IsAssignableFrom(item) && !item.GetTypeInfo().IsAbstract)
                {
                    foreach (ConstructorInfo constructor in item.GetTypeInfo().DeclaredConstructors)
                    {
                        if (constructor.GetParameters().Length == 0)
                        {
                            IItem someItem = (IItem)itemAssembly.CreateInstance(item.FullName, false);
                            Items.Add(someItem);
                        }
                    }
                }
            }
        }

        public static List<IItem> Items { get; set; } = new List<IItem>();
    }
}