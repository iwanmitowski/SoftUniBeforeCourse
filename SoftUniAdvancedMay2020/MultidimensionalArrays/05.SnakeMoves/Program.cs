using System;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            char[,] matrix = new char[rows, cols];

            string word = Console.ReadLine();
            int lastIndex = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i%2==0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (lastIndex > word.Length-1)
                        {
                            lastIndex = 0;
                        }

                        matrix[i, j] = word[lastIndex];
                        lastIndex++;
                    }
                }
                else 
                {
                    for (int j = cols-1; j >= 0; j--)
                    {
                        if (lastIndex > word.Length-1)
                        {
                            lastIndex = 0;
                        }
                        matrix[i, j] = word[lastIndex];
                        lastIndex++;
                    }
                }
               
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
