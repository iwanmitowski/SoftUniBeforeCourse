using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Cat : Feline
    {
        private const double catWeight = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override void Eat(IFood food)
        {
            var foodType = food.GetType().Name;
            var animalType = this.GetType().Name;

            if (foodType == "Vegetable" || foodType == "Meat")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * catWeight;
            }
            else
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}"!);

            }


        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
