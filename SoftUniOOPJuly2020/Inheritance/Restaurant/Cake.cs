using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Cake : Dessert
    {
        private const int cakeGrams = 250;
        private const int cakeCals = 1000;
        private const int cakePrice = 5;
        public Cake(string name) : base(name, cakePrice, cakeGrams, cakeCals)
        {
        }
    }
}
