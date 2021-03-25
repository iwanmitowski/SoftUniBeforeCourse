using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ConnectedAreasInMatrix
{
    class Program
    {
        static char[,] matrix;
        static List<Area> areas = new List<Area>();

        static char wall = '*';
        static char visited = 'v';

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = input[j];

                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    FindConnectedArea(matrix, i, j);
                }
            }

            int areaCounter = 1;
            Console.WriteLine($"Total areas found: {areas.Count}");
            foreach (var area in areas.OrderByDescending(x=>x.Size)
                                      .ThenBy(x=>x.Rows)
                                      .ThenBy(x=>x.Cols)
                                      )
            {
                Console.WriteLine($"Area #{areaCounter++} at ({area.Rows}, {area.Cols}), size: {area.Size}");
            }
        }
        private static void FindConnectedArea(char[,] matrix, int i, int j)
        {
            if (matrix[i, j] == wall || matrix[i, j] == visited)
            {
                return;
            }

            Area area = new Area(i, j);
            FindAreas(matrix, i, j, area);
            areas.Add(area);
        }

        private static void FindAreas(char[,] matrix, int row, int col, Area area)
        {
            if (CellIsViable(row, col) == false)
            {
                return;
            }

            Mark(row, col);

            area.Size++;

            FindAreas(matrix, row, col + 1, area);
            FindAreas(matrix, row + 1, col, area);
            FindAreas(matrix, row - 1, col, area);
            FindAreas(matrix, row, col - 1, area);

        }

        private static void Mark(int row, int col)
        {
            matrix[row, col] = 'v';
        }

        private static bool CellIsViable(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1) &&
                matrix[row, col] != visited &&
                matrix[row, col] != wall;

        }
    }

    class Area
    {

        public Area(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Size = 0;
        }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int Size { get; set; }
    }
}
