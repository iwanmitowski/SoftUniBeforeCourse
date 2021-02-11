using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) : base(name,CoffeePrice,CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50M;
        public double Caffeine { get; set; }
    }
}
