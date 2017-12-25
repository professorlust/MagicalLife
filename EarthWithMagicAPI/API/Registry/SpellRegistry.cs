﻿// <copyright file="SpellRegistry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Registry
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using EarthWithMagicAPI.API.Interfaces.Spells;

    public static class SpellRegistry
    {

        static SpellRegistry()
        {
            Assembly itemAssembly = Assembly.Load(new AssemblyName("EarthWithMagicMagic"));
            Type interfaceType = typeof(ISpell);

            foreach (Type item in itemAssembly.GetTypes())
            {
                if (interfaceType.IsAssignableFrom(item) && !item.GetTypeInfo().IsAbstract)
                {
                    foreach (ConstructorInfo constructor in item.GetTypeInfo().DeclaredConstructors)
                    {
                        if (constructor.GetParameters().Length == 0)
                        {
                            ISpell someItem = (ISpell)itemAssembly.CreateInstance(item.FullName, false);
                            Spells.Add(someItem);
                        }
                    }
                }
            }
        }

        public static List<ISpell> Spells { get; set; } = new List<ISpell>();

        /// <summary>
        /// Returns a list of all the spells that are under or equal to the specified power.
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public static List<ISpell> GetSpellsUnderPower(int power)
        {
            if (Spells.Count == 0)
            {
            }

            List<ISpell> spells = new List<ISpell>();

            foreach (ISpell item in Spells)
            {
                if (item.PowerRequired <= power)
                {
                    spells.Add(item);
                }
            }

            return spells;
        }
    }
}