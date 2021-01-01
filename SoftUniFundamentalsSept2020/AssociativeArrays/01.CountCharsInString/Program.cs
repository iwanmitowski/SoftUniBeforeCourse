using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (dictionary.ContainsKey(letter) == false)
                    {
                        dictionary.Add(letter, 0);
                    }
                    dictionary[letter]++;
                }
                
            }

            foreach (var letter in dictionary)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }

        }
    }
}
