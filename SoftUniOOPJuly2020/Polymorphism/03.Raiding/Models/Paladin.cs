using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    class Paladin : BaseHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name) : base(name, PaladinPower)
        {
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {this.Power}";
        }
    }
}
