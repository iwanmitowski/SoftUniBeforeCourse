using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.PermutationsWithoutRepetitions
{
    class Program
    {
        static string[] word;
        static void Main(string[] args)
        {
            word = Console.ReadLine().Split(' ').ToArray();

            Permutation(0);
        }

        private static void Permutation(int index)
        {
            if (index == word.Length)
            {
                Console.WriteLine(string.Join(" ", word));
                return;
            }

            var usedLetters = new HashSet<string>();

            for (int i = index; i < word.Length; i++)
            {
                if (usedLetters.Contains(word[i]) == false)
                {
                    string currentChar = word[index];
                    word[index] = word[i];
                    word[i] = currentChar;

                    Permutation(index + 1);

                    word[i] = word[index];
                    word[index] = currentChar;

                    usedLetters.Add(word[index]);
                }
            }
        }
    }
}
