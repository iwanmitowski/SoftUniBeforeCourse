using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name) : base(name, WarriorPower)
        {
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {this.Power} damage";
        }
    }
}
