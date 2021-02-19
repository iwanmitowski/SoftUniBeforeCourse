using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    abstract class BaseHero : IHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {this.Name} ";
        }
    }
}
