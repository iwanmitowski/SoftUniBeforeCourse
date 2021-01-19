using System;
using System.Linq;

namespace _05.SquareMaxSum
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
                int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int biggestSum = int.MinValue;
            int row = -1;
            int col = -1;

            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < cols-1; j++)
                {
                    int currentSquareSum = 0;
                    currentSquareSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (currentSquareSum>biggestSum)
                    {
                        row = i;
                        col = j;
                        biggestSum = currentSquareSum;
                    }

                }
            }

            Console.WriteLine($"{matrix[row,col]} {matrix[row, col+1]}");
            Console.WriteLine($"{matrix[row+1,col]} {matrix[row+1, col+1]}");

            Console.WriteLine(biggestSum);

        }
    }
}
