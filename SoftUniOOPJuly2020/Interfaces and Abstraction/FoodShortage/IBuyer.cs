using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    interface IBuyer
    {
        public int Food { get;}
        void BuyFood();
    }
}
