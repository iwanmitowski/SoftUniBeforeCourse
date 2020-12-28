using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegative
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = numbers
                .Where(n => n >= 0)
                .Reverse()
                .ToList();

            if (result.Count>0)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("empty");
            }
            
        }
    }
}
