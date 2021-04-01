using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Words
{
    class Program
    {
        static int count = 0;
        static char[] word;
        static void Main(string[] args)
        {
            word = Console.ReadLine().ToCharArray();
            int wordDistinctCharacters = word.Distinct().Count();
            
            if (wordDistinctCharacters == word.Length)
            {
                count = Fact(wordDistinctCharacters);
            }
            else
            {
                WordPermutations(0);
            }
            Console.WriteLine(count);
        }

        private static int Fact(int wordDistinctCharacters)
        {
            int fact = 1;
            for (int i = 2; i <= wordDistinctCharacters; i++)
            {
                fact *= i;
            }

            return fact;
        }

        private static void WordPermutations(int index)
        {
            if (index == word.Length)
            {
                bool isValid = true;

                for (int i = 0; i < word.Length - 1; i++)
                {
                    if (word[i] == word[i + 1])
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    count++;
                }

                return;
            }

            var usedLetters = new HashSet<char>();

            for (int i = index; i < word.Length; i++)
            {
                if (!usedLetters.Contains(word[i]))
                {
                    char currentChar = word[index];
                    word[index] = word[i];
                    word[i] = currentChar;

                    WordPermutations(index + 1);

                    usedLetters.Add(word[index]);

                    word[i] = word[index];
                    word[index] = currentChar;
                }



            }
        }
    }
}
