using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    class StationaryPhone : ICallable
    {
        private readonly List<string> numbers;
        
        public void Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                Console.WriteLine($"Dialing... {number}");

            }
            else
            {
                throw new ArgumentException("Invalid number!");

            }


        }
    }
}
