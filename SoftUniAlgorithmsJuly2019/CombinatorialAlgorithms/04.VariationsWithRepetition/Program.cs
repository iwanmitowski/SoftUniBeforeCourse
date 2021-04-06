using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.VariationsWithRepetition
{
    class Program
    {
        static string[] word;
        static string[] slots;

        static void Main(string[] args)
        {
            word = Console.ReadLine().Split().ToArray();
            int n = int.Parse(Console.ReadLine());
            slots = new string[n];

            GenVariations(0);
        }

        private static void GenVariations(int index)
        {
            if (index == slots.Length)
            {
                Console.WriteLine(string.Join(" ", slots));
                return;
            }

            var usedLetters = new HashSet<string>();

            for (int i = 0; i < word.Length; i++)
            {
                if (usedLetters.Contains(word[i]) == false)
                {
                    slots[index] = word[i];
                    usedLetters.Add(word[i]);

                    GenVariations(index + 1);

                    usedLetters.Remove(word[i]);
                }
            }
        }
    }
}
