using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.World.Items;

namespace MagicalLifeAPI.World.Resources.Tree
{
    /// <summary>
    /// An oak tree.
    /// </summary>
    public class OakTree : TreeBase
    {
        private static readonly string Name = "Oak Tree";
        private static readonly int Dura = 20;

        public OakTree() : base(Name, Dura)
        {
            this.HarvestingBehavior = new DropWhenCompletelyHarvested(new List<Base.Item>()
            {
                new StoneRubble(this.Durability)
            });
        }

        public override AbstractHarvestable HarvestingBehavior { get; set; }

        public override List<AbstractVisual> GetVisuals()
        {
            throw new NotImplementedException();
        }
    }
}
