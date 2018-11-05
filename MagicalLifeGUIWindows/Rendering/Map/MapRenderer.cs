﻿using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeGUIWindows.Rendering.Map
{
    /// <summary>
    /// Handles rendering the map.
    /// </summary>
    public static class MapRenderer
    {
        public static MapBatch MapDrawer { get; private set; } = new MapBatch();

        /// <summary>
        /// Draws the tiles that make up the map.
        /// </summary>
        /// <param name="spBatch"></param>
        public static void DrawMap(SpriteBatch spBatch, int dimension)
        {
            MapDrawer.UpdateSpriteBatch(spBatch);

            foreach (Tile tile in World.Dimensions[dimension])
            {
                Point2D start = new Point2D(RenderInfo.tileSize.X * tile.MapLocation.X, RenderInfo.tileSize.Y * tile.MapLocation.Y);
                DrawTile(tile, start);
            }

            DrawEntities(dimension);
        }

        public static void DrawEntities(int dimension)
        {
            int chunkHeight = Chunk.Height;
            int chunkWidth = Chunk.Width;
            int xSize = World.Dimensions[dimension].Width;
            int ySize = World.Dimensions[dimension].Height;

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    Chunk chunk = World.Dimensions[dimension].GetChunk(x, y);

                    int length = chunk.Creatures.Count;
                    for (int i = 0; i < length; i++)
                    {
                        KeyValuePair<System.Guid, Living> item = chunk.Creatures.ElementAt(i);

                        if (item.Value != null)
                        {
                            Point2D livingScreenLocation = new Point2D((int)(item.Value.ScreenLocation.X * Tile.GetTileSize().X), (int)(item.Value.ScreenLocation.Y * Tile.GetTileSize().Y));
                            MasterLog.DebugWriteLine("Entity: " + item.Value.ID.ToString() + "Screen position: " + item.Value.ScreenLocation.ToString());
                            item.Value.Visual.ScreenTopLeft = livingScreenLocation;
                            MapDrawer.AddRenderJob(item.Value.Visual);
                        }
                    }
                }
            }
        }


        private static void DrawItems(MapBatch spBatch, Tile tile, Rectangle target)
        {
            if (tile.Item != null)
            {
                Texture2D texture = AssetManager.Textures[tile.Item.TextureIndex];
                //MapDrawer.AddRenderJob()
                MapDrawer.Draw(texture, target, RenderLayer.Items);
            }
        }

        /// <summary>
        /// Draws a tile.
        /// </summary>
        private static void DrawTile(Tile tile, Point2D start)
        {
            //A target location for 32x textures to be centered in the tile, without being enlarged.
            Rectangle x32Target = new Rectangle(start.X + 16, start.Y + 16, 32, 32);

            MapDrawer.AddRenderJob(tile.CompositeRenderer.RenderQueue);
            //tile.CompositeRenderer.Render(MapDrawer, start);
            DrawItems(MapDrawer, tile, new Rectangle(start.X, start.Y, Tile.GetTileSize().X, Tile.GetTileSize().Y));

            if (tile.ImpendingAction == MagicalLifeAPI.Entity.AI.Task.ActionSelected.Mine)
            {
                MapDrawer.Draw(AssetManager.Textures[AssetManager.NameToIndex[TextureLoader.GUIPickaxeMapIcon]], x32Target, RenderLayer.GUI);
            }
        }
    }
}