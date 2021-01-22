using System;
using System.Collections.Generic;

namespace _01.CountSameValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var num in numbers)
            {
                if (dictionary.ContainsKey(num))
                {
                    dictionary[num]++;
                }
                else
                {
                    dictionary.Add(num, 1);

                }
            }

            foreach (var num in dictionary)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
