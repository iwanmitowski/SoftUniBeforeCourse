using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Hen : Bird
    {
        private const double henWeight = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * henWeight;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
