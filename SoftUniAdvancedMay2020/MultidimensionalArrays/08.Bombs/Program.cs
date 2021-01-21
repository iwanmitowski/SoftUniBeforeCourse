using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] colValues = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = colValues[j];
                }
            }

            int[] bombsCoordinates = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < bombsCoordinates.Length; i += 2)
            {
                int currRow = bombsCoordinates[i];
                int currCol = bombsCoordinates[i + 1];

                int explosion = matrix[currRow, currCol];

                if (explosion<=0)
                {
                    continue;
                }

                //Previous row
                if (currRow - 1 >= 0 && currCol - 1 >= 0 && matrix[currRow - 1, currCol - 1] > 0)
                {
                    matrix[currRow - 1, currCol - 1] -= explosion;
                }
                if (currRow - 1 >= 0 && matrix[currRow - 1, currCol] > 0)
                {
                    matrix[currRow - 1, currCol] -= explosion;
                }
                if (currRow - 1 >= 0 && currCol + 1 < size && matrix[currRow - 1, currCol + 1] > 0)
                {
                    matrix[currRow - 1, currCol + 1] -= explosion;
                }
                //Current row
                if (currCol - 1 >= 0 && matrix[currRow, currCol - 1] > 0)
                {
                    matrix[currRow, currCol - 1] -= explosion;
                }

                matrix[currRow, currCol] = 0;

                if (currCol + 1 < size && matrix[currRow, currCol + 1] > 0)
                {
                    matrix[currRow, currCol + 1] -= explosion;
                }
                //Next row
                if (currRow + 1 < size && currCol - 1 >= 0 && matrix[currRow + 1, currCol - 1] > 0)
                {
                    matrix[currRow + 1, currCol - 1] -= explosion;
                }
                if (currRow + 1 < size && matrix[currRow + 1, currCol] > 0)
                {
                    matrix[currRow + 1, currCol] -= explosion;
                }
                if (currRow + 1 < size && currCol + 1 < size && matrix[currRow + 1, currCol + 1] > 0)
                {
                    matrix[currRow + 1, currCol + 1] -= explosion;
                }
            }
            int alive = 0;
            int sum = 0;

            foreach (int num in matrix)
            {
                if (num>0)
                {
                    alive++;
                    sum += num;
                }
            }

            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
