using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    class InvalidFoodException : Exception
    {
        public InvalidFoodException(string message) : base(message)
        {
        }
    }
}
