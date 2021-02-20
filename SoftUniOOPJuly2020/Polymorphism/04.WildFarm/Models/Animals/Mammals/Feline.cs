using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, string livingRegion,string breed) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
