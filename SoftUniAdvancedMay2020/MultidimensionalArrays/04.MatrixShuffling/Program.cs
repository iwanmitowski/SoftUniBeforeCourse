using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            string[,] matrix = new string[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "END")
            {
                if (!isValid(input))
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                int row1 = int.Parse(input[1]);
                int col1 = int.Parse(input[2]);
                int row2 = int.Parse(input[3]);
                int col2 = int.Parse(input[4]);

                if (!areValidCoordiantes(matrix, row1, col1)|| !areValidCoordiantes(matrix, row2, col2))
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                string currentElement = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = currentElement;

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            

        }

        private static bool areValidCoordiantes(string[,] matrix, int row, int col)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);


            return row >= 0 && row < rowLength && col >= 0 && col < colLength;
        }

        private static bool isValid(string[] input)
        {
            return input.Length == 5 && input[0] == "swap";
        }
    }
}
