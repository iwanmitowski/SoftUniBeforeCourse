using System;
using System.Linq;

namespace Arrays_Praktice_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumVowels = 0;
            int sumConsonant = 0;
            int sum = 0;
            string vowels = "EeUuIiOoAa"; // добавено

            int[] arrayOfSums = new int[n];

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                for (int j = 0; j < name.Length; j++)
                {
                    char currentLetter = name[j]; // това трябва да е чар

                    if (vowels.Contains(currentLetter)) // променено
                    {
                        sumVowels += currentLetter * name.Length;
                    }
                    else
                    {
                        sumConsonant += currentLetter / name.Length;
                    }
                }
                sum = sumVowels + sumConsonant;
                arrayOfSums[i] = sum;

                sumVowels = 0;
                sumConsonant = 0;
                sum = 0;

            }

            Array.Sort(arrayOfSums);
            for (int i = 0; i < arrayOfSums.Length; i++)
            {
                Console.WriteLine(arrayOfSums[i]);
            }


        }
    }
}