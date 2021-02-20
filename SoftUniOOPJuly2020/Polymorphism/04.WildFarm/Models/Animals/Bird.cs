using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class Bird : Animal, IBird
    {
        public Bird(string name, double weight,double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; protected set; }

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
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
