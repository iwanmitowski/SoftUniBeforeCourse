using System;
using System.Linq;

namespace _05.GeneratingCombinations
{
    class Program
    {
        static void Combinations (int[] set, int[] vector, int index, int border)
        {
            if (index==vector.Length)
            {
                Console.WriteLine(string.Join(" ",vector));
                return;
                
            }

            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];
                Combinations(set, vector, index + 1, i + 1);
            }
        }
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int length = int.Parse(Console.ReadLine());
            Combinations(set, new int[length], 0, 0);
        }
    }
}
