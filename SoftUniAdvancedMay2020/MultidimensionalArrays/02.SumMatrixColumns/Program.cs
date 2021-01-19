using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            for (int i = 0; i < cols; i++)
            {
                int sum = 0;
                for (int j = 0; j < rows; j++)
                {
                    sum += matrix[j, i];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
