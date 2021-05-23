using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MinimumEditDistance
{

    class Program
    {
        static List<string> commands;
        static string first;
        static string second;

        static int costReplace;
        static int costInsert;
        static int costDelete;

        static int[,] matrix;
        static void Main(string[] args)
        {
            //Not working fully

            commands = new List<string>();

            costReplace = int.Parse(Console.ReadLine().Split()[2]);
            costInsert = int.Parse(Console.ReadLine().Split()[2]);
            costDelete = int.Parse(Console.ReadLine().Split()[2]);

            first = string.Join("", Console.ReadLine().Skip(5));
            second = string.Join("", Console.ReadLine().Skip(5));

            matrix = new int[first.Length + 1, second.Length + 1];

            for (int i = 1; i <= second.Length; i++)
            {
                matrix[0, i] = matrix[0, i - 1] + costInsert;
            }

            for (int i = 1; i <= first.Length; i++)
            {
                matrix[i, 0] = matrix[i - 1, 0] + costDelete;
            }

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1];
                    }
                    else
                    {
                        int delete = matrix[i - 1, j] + costDelete;
                        int insert = matrix[i, j - 1] + costInsert;
                        int replace = matrix[i - 1, j - 1] + costReplace;

                        matrix[i, j] = Math.Min(replace, Math.Min(delete, insert));
                    }
                }
            }

            for (int i = 0; i <= first.Length; i++)
            {
                for (int j = 0; j <= second.Length; j++)
                {
                    Console.Write(matrix[i, j] + " ");

                }

                Console.WriteLine();
            }

            Console.WriteLine($"Minimum edit distance : {matrix[first.Length, second.Length]}");
            printEditOperations(first.Length - 1, second.Length - 1);

            Console.WriteLine(string.Join(Environment.NewLine, commands));

        }

        static void printEditOperations(int i, int j)
        {

            if (i == 0)
            {
                for (i = 1; i <= j; i++)
                {
                    commands.Add($"INSERT({j}, {second[i]})");
                }
            }
            else if (j == 0)
            {
                for (j = 1; j <= i; j++)
                {
                    commands.Add($"DELETE({j - 1})");
                }
            }
            else if (i > 0 && j > 0)
            {
                if (matrix[i, j] == matrix[i - 1, j - 1] + (first[i] == second[j] ? 0 : costReplace))
                {
                    printEditOperations(i - 1, j - 1);
                    if ((first[i] == second[j] ? 0 : costReplace) > 0)
                    {
                        commands.Add($"REPLACE({i}, {second[j]})");
                    }
                }
                else if (matrix[i, j] == matrix[i, j - 1] + costInsert)
                {
                    printEditOperations(i, j - 1);
                    commands.Add($"INSERT({i - 1}, {second[j - 1]})");
                }
                else if (matrix[i, j] == matrix[i - 1, j] + costDelete)
                {
                    printEditOperations(i - 1, j);
                    commands.Add($"DELETE({i - 1})");
                }
            }
        }
    }
}

