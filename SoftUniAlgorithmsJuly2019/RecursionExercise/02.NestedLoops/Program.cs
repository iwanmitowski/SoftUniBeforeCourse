using System;

namespace _02.NestedLoops
{
    class Program
    {
        static int[] vector;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            vector = new int[n];

            LoopsSimulator(vector,n,0);
        }

        private static void LoopsSimulator(int[] vector, int n, int index)
        {
            if (index==vector.Length)
            {
                Console.WriteLine(string.Join(" ",vector));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                vector[index] = i;
                LoopsSimulator(vector, n, index + 1);
            }
        }
    }
}
