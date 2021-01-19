using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int diagonal = 0;

            int row = 0;
            int col = 0;

            for (int i = 0; i < size; i++)
            {
                diagonal += matrix[row, col];

                row++;
                col++;
            }

            Console.WriteLine(diagonal);

        }
    }
}
