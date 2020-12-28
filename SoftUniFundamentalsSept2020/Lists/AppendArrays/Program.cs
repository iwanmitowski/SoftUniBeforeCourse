using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split("|")
                .ToList();

            numbers.Reverse();

            List<string> result = new List<string>();

            foreach (string item in numbers)
            {
                string[] num = item.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (string element in num)
                {
                    result.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
