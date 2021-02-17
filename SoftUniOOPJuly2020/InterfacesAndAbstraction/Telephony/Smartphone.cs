using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    class Smartphone : ICallable, IBrowsable
    {
        

        public void Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }
            Console.WriteLine($"Browsing: {url}!");
        }
       
        public void Call(string number)
        {
            if (number.All(char.IsDigit))
            {
                Console.WriteLine($"Calling... {number}");

            }
            else
            {
                throw new ArgumentException("Invalid number!");

            }

        }
    }
}
