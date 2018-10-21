using MagicalLifeAPI.Sound;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    [ProtoContract]
    public class DropWhenCompletelyHarvested : AbstractHarvestable
    {
        [ProtoMember(1)]
        protected List<Item> Items { get; set; }

        public DropWhenCompletelyHarvested(List<Item> items)
        {
            this.Items = items;
        }

        public DropWhenCompletelyHarvested()
        {
        }

        public override List<Item> Mined()
        {
            return this.Items;
        }

        protected override List<Item> HarvestedPercent(float percentMined)
        {
            FMODUtil.RaiseEvent(EffectsTable.PickaxeHit);
            return null;
        }
    }
}