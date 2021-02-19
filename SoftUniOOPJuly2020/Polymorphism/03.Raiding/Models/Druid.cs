using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    class Druid : BaseHero
    {
        private const int DruidPower = 80;

        public Druid(string name) : base(name, DruidPower)
        {
        }
        public override string CastAbility()
        {
            return base.CastAbility()+$"healed for {this.Power}";
        }
    }
}
