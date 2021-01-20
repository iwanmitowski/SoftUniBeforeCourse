using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] colInput = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = colInput[j];
                }
            }

            int counter = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    string curr = matrix[i, j];
                    if (matrix[i,j+1]== curr && matrix[i+1,j]== curr && matrix[i + 1, j+1] == curr)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);

        }
    }
}
