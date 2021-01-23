using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> symbolNTimes = new SortedDictionary<char, int>();

            foreach (char c in text)
            {
                if (symbolNTimes.ContainsKey(c)==false)
                {
                    symbolNTimes.Add(c, 0);
                }
                symbolNTimes[c]++;
            }

            foreach ((char symbol, int count) in symbolNTimes)
            {
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}
