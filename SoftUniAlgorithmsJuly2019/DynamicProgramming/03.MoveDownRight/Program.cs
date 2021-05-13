using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MoveDownRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];
            int[,] memoMatrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            memoMatrix[0, 0] = matrix[0, 0];

            //First Row
            for (int i = 1; i < n; i++)
            {
                memoMatrix[0, i] = matrix[0, i] + memoMatrix[0, i - 1];
            }

            //First Col
            for (int i = 1; i < m; i++)
            {
                memoMatrix[i, 0] = matrix[i, 0] + memoMatrix[i - 1, 0];
            }

            //The other matrix part
            for (int row = 1; row < n; row++)
            {
                for (int col = 1; col < m; col++)
                {
                    int left = memoMatrix[row, col - 1] + matrix[row, col];
                    int up = memoMatrix[row - 1, col] + matrix[row, col];

                    memoMatrix[row, col] = Math.Max(up, left);
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {

                    Console.Write(memoMatrix[row, col]+ " ");
                }
                Console.WriteLine();
            }

            Stack<string> pathBackwards = new Stack<string>();

            int currentRow = n - 1;
            int currentCol = m - 1;

            while (currentRow >= 0 && currentCol >= 0)
            {
                pathBackwards.Push($"[{currentRow}, {currentCol}]");

                int left = memoMatrix[currentRow, currentCol - 1 < 0? 0: currentCol - 1];
                int up = memoMatrix[currentRow - 1 < 0 ? 0 : currentRow - 1, currentCol];

                if (left >= up)
                {
                    if (currentCol==0)
                    {
                        currentRow--;
                    }
                    else
                    {
                        currentCol--;
                    }
                }
                else
                {
                    currentRow--;
                }

            }

            Console.WriteLine(string.Join(" ", pathBackwards));
        }
    }
}
