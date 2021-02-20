using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract void Eat(IFood food);
        public abstract string ProduceSound();

    }
}
