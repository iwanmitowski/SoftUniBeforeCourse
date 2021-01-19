using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            int totalSum = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                int currentSum = currentRow.Sum();
                totalSum += currentSum;

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(totalSum);
        }
    }
}
