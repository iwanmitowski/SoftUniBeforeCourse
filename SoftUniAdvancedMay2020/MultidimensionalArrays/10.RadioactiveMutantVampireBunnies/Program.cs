using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            char[,] field = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;



            for (int i = 0; i < rows; i++)
            {
                char[] fieldCols = Console.ReadLine().ToCharArray();

                for (int j = 0; j < cols; j++)
                {
                    if (fieldCols[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }

                    field[i, j] = fieldCols[j];
                }
            }

            string moves = Console.ReadLine();
            bool isWon = false;

            foreach (char move in moves)
            {
                int currentPlayerRow = playerRow;
                int currentPlayerCol = playerCol;

                switch (move)
                {
                    case 'U':
                        currentPlayerRow--;
                        break;
                    case 'D':
                        currentPlayerRow++;
                        break;
                    case 'L':
                        currentPlayerCol--;
                        break;
                    case 'R':
                        currentPlayerCol++;
                        break;
                    default:
                        break;
                }



                if (currentPlayerRow < 0 || currentPlayerRow >= rows || currentPlayerCol < 0 || currentPlayerCol >= cols)
                {
                    field[playerRow, playerCol] = '.';
                    isWon = true;
                }
                else
                {
                    if (field[currentPlayerRow, currentPlayerCol] == '.')
                    {
                        field[currentPlayerRow, currentPlayerCol] = 'P';
                        field[playerRow, playerCol] = '.';
                        playerRow = currentPlayerRow;
                        playerCol = currentPlayerCol;
                    }
                    else
                    {
                        field[playerRow, playerCol] = '.';
                        playerRow = currentPlayerRow;
                        playerCol = currentPlayerCol;
                    }
                }


                List<int> bunniesRowsCols = new List<int>();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (field[i, j] == 'B')
                        {
                            bunniesRowsCols.Add(i);
                            bunniesRowsCols.Add(j);
                        }
                    }
                }

                field = SpreadingBunnies(field, bunniesRowsCols);

                if (isWon == false && field[currentPlayerRow, currentPlayerCol] == 'B')
                {

                    break;
                }

                if (isWon)
                {

                    break;
                }

                playerRow = currentPlayerRow;
                playerCol = currentPlayerCol;


            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }



            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        static char[,] SpreadingBunnies(char[,] field, List<int> bunniesRowsCols)
        {
            for (int i = 0; i < bunniesRowsCols.Count; i += 2)
            {
                int currentBunnyRow = bunniesRowsCols[i];
                int currentBunnyCol = bunniesRowsCols[i + 1];

                if (currentBunnyRow - 1 >= 0)
                {
                    field[currentBunnyRow - 1, currentBunnyCol] = 'B';
                }
                if (currentBunnyRow + 1 < field.GetLength(0))
                {
                    field[currentBunnyRow + 1, currentBunnyCol] = 'B';
                }
                if (currentBunnyCol - 1 >= 0)
                {
                    field[currentBunnyRow, currentBunnyCol - 1] = 'B';
                }
                if (currentBunnyCol + 1 < field.GetLength(1))
                {
                    field[currentBunnyRow, currentBunnyCol + 1] = 'B';
                }

            }

            return field;
        }
    }
}
