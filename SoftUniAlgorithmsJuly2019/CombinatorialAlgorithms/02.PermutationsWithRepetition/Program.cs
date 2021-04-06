using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PermutationsWithRepetition
{
    class Program
    {

        static string[] word;
        static void Main(string[] args)
        {
            word = Console.ReadLine().Split().ToArray();

            Permutations(0);
        }

        private static void Permutations(int index)
        {
            if (index==word.Length)
            {
                Console.WriteLine(string.Join(" ",word));
                return;
            }

            var usedLetters = new HashSet<string>();

            for (int i = index; i < word.Length; i++)
            {
                if (usedLetters.Contains(word[i])==false)
                {
                    string currentChar = word[index];
                    word[index] = word[i];
                    word[i] = currentChar;

                    Permutations(index + 1);
                   
                    word[i] = word[index];
                    word[index] = currentChar;

                    usedLetters.Add(word[index]);

                }

            }
        }
    }
}
