using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    class Cake : BakedFood
    {
        private const int CakePortion = 245;
        public Cake(string name, decimal price) : base(name, CakePortion, price)
        {
        }
    }
}
