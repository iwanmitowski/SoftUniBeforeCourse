using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Tiger : Feline
    {
        private const double tigerWeight = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override void Eat(IFood food)
        {
            var foodType = food.GetType().Name;
            var animalType = this.GetType().Name;

            if (foodType != "Meat")
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * tigerWeight;
        }
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
