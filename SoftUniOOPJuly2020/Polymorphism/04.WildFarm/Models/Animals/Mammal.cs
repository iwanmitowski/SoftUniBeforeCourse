using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Mammal : Animal, IMammal
    {
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; protected set; }

        public override void Eat(IFood food)
        {
            throw new NotImplementedException();
        }

        public override string ProduceSound()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
