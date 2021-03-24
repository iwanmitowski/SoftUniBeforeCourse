using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PathsInLabyrinth
{
    class Program
    {
        static char[,] field;
        static List<char> path = new List<char>();
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            field = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string col = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = col[j];
                }
            }

            Solve(0, 0, 'S');
        }

        private static void Solve(int row, int col, char direction)
        {
            if (CellIsViable(row,col)==false)
            {
                return;
            }

            path.Add(direction);

            if (field[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", path.Skip(1)));
                               
            }
            else if (!IsVisited(row, col)&&IsFree(row,col))
            {
                Mark(row, col);
                Solve(row, col + 1, 'R');
                Solve(row, col - 1, 'L');
                Solve(row + 1, col, 'D');
                Solve(row - 1, col, 'U');
                UnMark(row, col);

            }

            path.RemoveAt(path.Count - 1);

        }

        private static bool IsFree(int row, int col)
        {
            return field[row, col] == '-';
        }

        private static bool IsVisited(int row, int col)
        {
            if (field[row,col]=='v')
            {
                return true;
            }

            return false;
        }

        private static void UnMark(int row, int col)
        {
            field[row, col] = '-';

        }

        private static void Mark(int row, int col)
        {
            field[row, col] = 'v';
        }

        private static bool CellIsViable(int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) &&
                col >= 0 && col < field.GetLength(1) &&
                field[row, col] != '*'&&
                field[row, col] != 'v'
                ;
        }
    }
}
