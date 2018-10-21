﻿using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeGUIWindows.Rendering.Map;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Visual.Rendering.AbstractVisuals
{
    /// <summary>
    /// Used to offset a texture by a certain amount.
    /// </summary>
    [ProtoContract]
    public class OffsetTexture : AbstractVisual
    {
        /// <summary>
        /// The texture that is being offset.
        /// </summary>
        private AbstractVisual Texture;

        private int XOffset;
        private int YOffset;


        /// <param name="priority"></param>
        /// <param name="offsetTexture">The texture that will be offset.</param>
        /// <param name="xOffset">The amount to offset the texture by.</param>
        /// <param name="yOffset">The amount to offset the texture by.</param>
        public OffsetTexture(int priority, AbstractVisual offsetTexture, int xOffset, int yOffset) : base(priority)
        {
            this.Texture = offsetTexture;
            this.XOffset = xOffset;
            this.YOffset = yOffset;
        }

        public override void Render(MapBatch batch, Point2D ScreenTopLeft)
        {
            this.Texture.Render(batch, new Point2D(ScreenTopLeft.X + this.XOffset, ScreenTopLeft.Y + this.YOffset));
        }
    }
}
