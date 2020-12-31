using System;
using System.Collections.Generic;
using System.Text;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (string word in input)
            {
                string currWord = word.ToLower();

                if (dictionary.ContainsKey(currWord))
                {
                    dictionary[currWord]++;
                }
                else
                {
                    dictionary.Add(currWord, 1);
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (var count in dictionary)
            {
                if (count.Value % 2 != 0)
                {
                    sb.Append(count.Key + " ");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
