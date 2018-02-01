﻿using System.Diagnostics;
using MagicalLifeAPI.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// Holds some utilities for world stuff.
    /// </summary>
    public static class WorldUtil
    {
        /// <summary>
        /// Returns a tile based on it's location in string format.
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public static Tile GetTileByID(Tile[,,] tiles, string str)
        {
            Point3D point = new Point3D(str);
            Debug.WriteLine("Get tile by ID: ");
            Debug.WriteLine(str);
            Debug.WriteLine(point.X + " " + point.Y + " " + point.Z);
            return tiles[point.X, point.Y, point.Z];
        }
    }
}
