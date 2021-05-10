using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.KnightTour
{
    class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new int[n, n];

            List<string> positions = new List<string>();

            matrix[0, 0] = 1;
            matrix[1, 2] = 2;

            int counter = 3;

            int knightRow = 1;
            int knightCol = 2;

            int moves = findPossibleMoves(knightRow, knightCol);

            while (moves != 0)
            {
                positions = findPossibleMovePositions(knightRow, knightCol);

                int minMoves = int.MaxValue;

                foreach (var item in positions)
                {
                    int[] knightMoveTokens = item
                        .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    int p = knightMoveTokens[0];
                    int q = knightMoveTokens[1];

                    int currentMovesCount = findPossibleMoves(p, q);

                    if (currentMovesCount < minMoves)
                    {
                        minMoves = currentMovesCount;
                        knightRow = p;
                        knightCol = q;
                    }
                }

                matrix[knightRow, knightCol] = counter++;

                moves = findPossibleMoves(knightRow, knightCol);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ".PadLeft(4));
                }
                Console.WriteLine();
            }

        }
        static List<string> findPossibleMovePositions(int p, int q)
        {
            var moves = new List<string>();

            int[] X = { 1, -1, 1, -1, 2, 2, -2, -2 };
            int[] Y = { 2, 2, -2, -2, 1, -1, 1, -1 };

            for (int i = 0; i < 8; i++)
            {
                int x = p + X[i];
                int y = q + Y[i];

                if (x >= 0
                    && y >= 0
                    && x < matrix.GetLength(0)
                    && y < matrix.GetLength(0)
                    && matrix[x, y] == 0)
                {
                    moves.Add($"{x},{y}");
                }
            }

            return moves;
        }

        static int findPossibleMoves(int p, int q)
        {
            int[] X = { 1, -1, 1, -1, 2, 2, -2, -2 };
            int[] Y = { 2, 2, -2, -2, 1, -1, 1, -1 };

            int count = 0;

            for (int i = 0; i < 8; i++)
            {
                int x = p + X[i];
                int y = q + Y[i];

                if (x >= 0
                    && y >= 0
                    && x < matrix.GetLength(0)
                    && y < matrix.GetLength(0)
                    && matrix[x, y] == 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
