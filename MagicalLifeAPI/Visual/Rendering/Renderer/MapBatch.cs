using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Visual.Rendering.Renderer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Rendering.Map
{
    /// <summary>
    /// Used to render objects in the map while accounting for things like offsets.
    /// </summary>
    public class MapBatch
    {
        private SpriteBatch SpriteBat;

        private RenderQueue RenderingQueue = new RenderQueue();

        /// <summary>
        /// Updates the internal handle to a new <see cref="SpriteBatch"/>.
        /// This should be called every frame.
        /// </summary>
        /// <param name="spBatch"></param>
        public void UpdateSpriteBatch(SpriteBatch spBatch)
        {
            this.SpriteBat = spBatch;
            this.RenderingQueue.Visuals.Clear();
        }

        /// <summary>
        /// Adds a render job to be completed at a later date.
        /// </summary>
        public void AddRenderJob(AbstractVisual visual)
        {
            this.RenderingQueue.Visuals.Add(visual);
        }

        /// <summary>
        /// Renders the backlog of rendering jobs to completion.
        /// </summary>
        public void RenderAll()
        {
            foreach (AbstractVisual item in this.RenderingQueue.Visuals)
            {
                item.Render(this);
            }
        }

        /// <summary>
        /// Draws the <paramref name="texture"/> at the <paramref name="target"/> location. Applies a standard white mask.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="target"></param>
        public void Draw(Texture2D texture, Rectangle target)
        {
            int x = target.X + RenderInfo.XViewOffset;
            int y = target.Y + RenderInfo.YViewOffset;

            this.SpriteBat.Draw(texture, new Rectangle(x, y, target.Width, target.Height), Color.White);
        }

        /// <summary>
        /// Draws a section of the texture at the target location.
        /// </summary>
        /// <param name="texture">The texture to draw.</param>
        /// <param name="target">The target location to draw at.</param>
        /// <param name="textureSection">The section of the texture that will be drawn.</param>
        public void Draw(Texture2D texture, Vector2 target, Rectangle textureSection)
        {
            float x = (float)Math.Round(target.X + RenderInfo.XViewOffset);
            float y = (float)Math.Round(target.Y + RenderInfo.YViewOffset);

            this.SpriteBat.Draw(texture, new Vector2(x, y), textureSection, Color.White);
        }

        public void Draw(Texture2D texture, Vector2 target)
        {
            int x = (int)Math.Round(target.X + RenderInfo.XViewOffset);
            int y = (int)Math.Round(target.Y + RenderInfo.YViewOffset);

            this.SpriteBat.Draw(texture, new Vector2(x, y), Color.White);
        }

        public void AddRenderJob(RenderQueue renderQueue)
        {
            foreach (AbstractVisual item in renderQueue.Visuals)
            {
                this.RenderingQueue.Visuals.Add(item);
            }
        }
    }
}