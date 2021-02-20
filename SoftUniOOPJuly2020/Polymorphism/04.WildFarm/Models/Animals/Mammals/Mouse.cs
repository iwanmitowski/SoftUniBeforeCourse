using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Mouse : Mammal
    {
        private const double mouseWeight = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            var foodType = food.GetType().Name;
            var animalType = this.GetType().Name;

            if (foodType == "Vegetable" || foodType == "Fruit")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * mouseWeight;
            }
            else
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}!");

            }

           
        }
        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
