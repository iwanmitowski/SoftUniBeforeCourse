using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Dog : Mammal
    {
        private const double dogWeight = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
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
            this.Weight += food.Quantity * dogWeight;
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
