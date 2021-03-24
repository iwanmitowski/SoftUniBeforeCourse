using System;
using System.Collections.Generic;

namespace _06._8QueensPuzzle
{
    class Program
    {
        static bool[,] board = new bool[8, 8];
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();
        static HashSet<int> attackedMainDiagonals = new HashSet<int>();
        static HashSet<int> attackedSecondaryDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            Solve(0);
        }

        private static void Solve(int row)
        {
            if (row == 8)
            {
                Print();
                return;
            }

            for (int col = 0; col < 8; col++)
            {
                if (!IsViableCell(row,col))
                {
                    MarkAllAttacked(row, col);
                    Solve(row + 1);
                    UnMarkAllAttacked(row, col);
                }
            }
        }

        private static void UnMarkAllAttacked(int row, int col)
        {
            board[row, col] = false;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedMainDiagonals.Remove(col - row);
            attackedSecondaryDiagonals.Remove(col + row);

        }

        private static void MarkAllAttacked(int row, int col)
        {
            board[row, col] = true;
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedMainDiagonals.Add(col - row);
            attackedSecondaryDiagonals.Add(col + row);

        }

        private static bool IsViableCell(int row, int col)
        {
            return attackedRows.Contains(row) ||
                   attackedCols.Contains(col) ||
                   attackedMainDiagonals.Contains(col - row) ||
                   attackedSecondaryDiagonals.Contains(col + row);
        }

        private static void Print()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == true)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
