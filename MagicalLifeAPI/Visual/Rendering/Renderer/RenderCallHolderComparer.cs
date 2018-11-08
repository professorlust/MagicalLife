using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Visual.Rendering.Renderer
{
    public class RenderCallHolderComparer : IComparer<RenderCallHolder>
    {
        public int Compare(RenderCallHolder x, RenderCallHolder y)
        {
            if (x.RenderLayer == y.RenderLayer)
            {
                //They are equal in priority.
                return 0;
            }

            if (x.RenderLayer > y.RenderLayer)
            {
                //x should be before y in priority.
                return 1;
            }
            else
            {
                //x should be behind y.
                return -1;
            }
        }
    }
}
