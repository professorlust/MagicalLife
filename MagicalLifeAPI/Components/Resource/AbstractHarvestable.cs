using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Components.Resource
{
    /// <summary>
    /// Anything that implements this must describe its behavior in terms of harvesting.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(2, typeof(DropWhenCompletelyHarvested))]
    public abstract class AbstractHarvestable
    {
        /// <summary>
        /// The total percentage of the <see cref="IHarvestable"/> that has been mined so far.
        /// </summary>
        [ProtoMember(1)]
        public float PercentHarvested { get; private set; }

        protected AbstractHarvestable()
        {
            this.PercentHarvested = 0;
        }

        public Type GetBaseType()
        {
            return typeof(AbstractHarvestable);
        }

        /// <summary>
        /// Called when the object is harvested up completely.
        /// </summary>
        /// <returns>Any items that should be dropped when completely harvested. Return null to drop nothing.</returns>
        public abstract List<Item> Mined();

        /// <summary>
        /// Called anytime the object is in the process of being harvested, but not totally harvested.
        /// Should the object be completely harvested in one step, this is called with 100%, then <see cref="Mined"/> is called.
        /// </summary>
        /// <param name="percentHarvested"></param>
        /// <returns>Any items that should be dropped due to the progress in harvesting the object. Return null to drop nothing.</returns>
        public List<Item> MineSomePercent(float percentHarvested)
        {
            this.PercentHarvested += percentHarvested;

            if (this.PercentHarvested < 1)
            {
                return this.HarvestedPercent(this.PercentHarvested);
            }
            else
            {
                return this.Mined();
            }
        }

        /// <param name="percent">The total percent mined so far.</param>
        /// <returns></returns>
        protected abstract List<Item> HarvestedPercent(float percent);
    }
}