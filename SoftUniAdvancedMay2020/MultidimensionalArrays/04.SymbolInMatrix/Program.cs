using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string currentRow = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            int row = -1;
            int col = -1;

            bool isFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        row = i;
                        col = j;
                        isFound = true;
                    }

                }
                if (isFound)
                {
                    break;
                }
            }

            if (row == -1 && col == -1)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
            else
            {
                Console.WriteLine($"({row}, {col})");
            }
        }
    }
}
