using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(num =>
                {
                    decimal currNum = decimal.Parse(num);
                    return currNum * 1.2M;

                })
                .ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }

        }
    }
}
