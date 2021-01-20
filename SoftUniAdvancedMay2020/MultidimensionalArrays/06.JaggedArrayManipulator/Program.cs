using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jagged = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }

            for (int i = 0; i < rows-1; i++)
            {
                if (jagged[i].Length==jagged[i+1].Length)
                {
                    jagged[i] = jagged[i].Select(e => e * 2).ToArray();
                    jagged[i+1] = jagged[i+1].Select(e => e * 2).ToArray();
                }
                else
                {
                    jagged[i] = jagged[i].Select(e => e / 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(e => e / 2).ToArray();
                }
            }

            string[] input = Console.ReadLine().Split();
            while (input[0]!="End")
            {
                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (!AreValidCoordinates(jagged,row,col))
                {
                    input = Console.ReadLine().Split();
                    continue;
                }

                if (command=="Add")
                {
                    jagged[row][col] += value;
                }
                else if (command=="Subtract")
                {
                    jagged[row][col] -= value;
                }

                input = Console.ReadLine().Split();
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }

        private static bool AreValidCoordinates(double[][] jagged,int row, int col)
        {
            return row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length;
        }
    }
}
