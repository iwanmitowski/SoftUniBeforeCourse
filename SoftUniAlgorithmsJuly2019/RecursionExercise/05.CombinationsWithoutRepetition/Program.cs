using System;

namespace _05.CombinationsWithoutRepetition
{
    class Program
    {
        static int[] vector;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            vector = new int[k];

            Combine(vector, 0, n, 1);
        }

        private static void Combine(int[] vector, int index, int n, int border)
        {
            if (index==vector.Length)
            {
                Console.WriteLine(string.Join(" ",vector));
                return;
            }

            for (int i = border; i <= n; i++)
            {
                vector[index] = i;
                Combine(vector, index + 1, n, border+1);
                border++;
            }
        }
    }
}
