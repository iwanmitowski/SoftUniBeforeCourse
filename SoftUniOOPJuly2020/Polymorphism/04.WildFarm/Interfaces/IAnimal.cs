using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        void Eat(IFood food);
        string ProduceSound();
    }
}
