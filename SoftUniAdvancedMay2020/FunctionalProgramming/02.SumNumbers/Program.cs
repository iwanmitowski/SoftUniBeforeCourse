using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parse = x => int.Parse(x);

            int[] numbers = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(parse)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
