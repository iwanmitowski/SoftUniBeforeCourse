using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Owl : Bird
    {
        private const double owlWeight = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            var foodType = food.GetType().Name;
            var animalType = this.GetType().Name;

            if (foodType!="Meat")
            {
                throw new InvalidFoodException($"{animalType} does not eat {foodType}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * owlWeight;
        }
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
