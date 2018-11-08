﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Visual.Rendering.Renderer
{
    /// <summary>
    /// Holds a call to a rendering method in <see cref="MapBatch"/>, as well as holding its render layer.
    /// </summary>
    public struct RenderCallHolder
    {
        public int RenderLayer;
        public Action Action;

        public RenderCallHolder(int renderLayer, Action action)
        {
            this.RenderLayer = renderLayer;
            this.Action = action;
        }
    }
}
