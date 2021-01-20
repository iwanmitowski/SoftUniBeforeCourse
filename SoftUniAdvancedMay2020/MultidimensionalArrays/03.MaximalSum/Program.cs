using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int maxSum = int.MinValue;
            int indexRows = 0;
            int indexCols = 0;


            for (int i = 0; i < rows - 2; i++)
            {
                
                for (int j = 0; j < cols - 2; j++)
                {
                    int sum = 0;
                    sum += matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                           matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                           matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (sum>maxSum)
                    {
                        maxSum = sum;
                        indexRows = i;
                        indexCols = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");

            Console.WriteLine($"{matrix[indexRows, indexCols]} {matrix[indexRows, indexCols+1]} {matrix[indexRows, indexCols+2]}");
            Console.WriteLine($"{matrix[indexRows+1, indexCols]} {matrix[indexRows+1, indexCols+1]} {matrix[indexRows+1, indexCols+2]}");
            Console.WriteLine($"{matrix[indexRows+2, indexCols]} {matrix[indexRows+2, indexCols+1]} {matrix[indexRows+2, indexCols+2]}");
        }
    }
}
