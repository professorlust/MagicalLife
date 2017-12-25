﻿namespace EarthMagicItems.Weapons.Throwing.Shurikens
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EarthWithMagicAPI.API.Interfaces.Items;

    public abstract class ShurikensBase : IThrowableWeapon
    {
        protected ShurikensBase(string name, double weight, string imagePath, string documentationPath, EarthWithMagicAPI.API.Util.Die uses, int chanceToHit, EarthWithMagicAPI.API.Damage attackDamage) : base(name, weight, imagePath, documentationPath, uses, chanceToHit, attackDamage)
        {
        }
    }
}
