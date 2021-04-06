using System;
using System.Linq;

namespace _06.CombinationsWithRepetition
{
    class Program
    {
        static string[] word;
        static string[] combinations;

        static void Main(string[] args)
        {
            word = Console.ReadLine().Split().ToArray();
            int n = int.Parse(Console.ReadLine());

            combinations = new string[n];

            GenCombinations(0, 0);
        }

        private static void GenCombinations(int index, int start)
        {
            if (index==combinations.Length)
            {
                Console.WriteLine(string.Join(" ",combinations));
                return;
            }

            for (int i = start; i < word.Length; i++)
            {
                combinations[index] = word[i];
                GenCombinations(index + 1, i);
            }
        }
    }
}
