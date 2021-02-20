using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
