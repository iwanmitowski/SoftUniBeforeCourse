using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    class Rogue : BaseHero
    {
        private const int RoguePower = 80;
        public Rogue(string name) : base(name, RoguePower)
        {
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {this.Power} damage";
        }
    }
}
