using System;
using System.Linq;

namespace _01.ConnectingCables
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] orderedSequence = sequence.OrderBy(x=>x).ToArray();

            int[,] matrix = new int[sequence.Length + 1, sequence.Length + 1];

            for (int i = 1; i <= sequence.Length; i++)
            {
                for (int j = 1; j <= sequence.Length; j++)
                {
                    if (sequence[i-1]==orderedSequence[j-1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            Console.WriteLine($"Maximum pairs connected: {matrix[sequence.Length,sequence.Length]}");
        }
    }
}
