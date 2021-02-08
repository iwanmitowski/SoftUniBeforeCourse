using System;

namespace _02.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int comandsCount = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            int playerRow = -1;
            int playerCol = -1;

            int finishRow = -1;
            int finishCol = -1;

            bool isWon = false;

            for (int i = 0; i < n; i++)
            {
                string colsInput = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = colsInput[j];
                    if (colsInput[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                    if (colsInput[j] == 'F')
                    {
                        finishRow = i;
                        finishCol = j;
                    }

                }
            }

            for (int i = 0; i < comandsCount; i++)
            {
                string command = Console.ReadLine();
                int currentRow = playerRow;
                int currentCol = playerCol;


                switch (command)
                {

                    case "up":
                        currentRow = Movement(command, currentRow, currentCol, n);
                        break;
                    case "down":
                        currentRow = Movement(command, currentRow, currentCol, n);
                        break;
                    case "left":
                        currentCol = Movement(command, currentRow, currentCol, n);
                        break;
                    case "right":
                        currentCol = Movement(command, currentRow, currentCol, n);
                        break;

                    default:
                        break;
                }


                if (field[currentRow, currentCol] == 'B')
                {
                    switch (command)
                    {

                        case "up":
                            currentRow = Movement(command, currentRow, currentCol, n);
                            break;
                        case "down":
                            currentRow = Movement(command, currentRow, currentCol, n);
                            break;
                        case "left":
                            currentCol = Movement(command, currentRow, currentCol, n);
                            break;
                        case "right":
                            currentCol = Movement(command, currentRow, currentCol, n);
                            break;

                        default:
                            break;
                    }
                }
                else if (field[currentRow, currentCol] == 'T')
                {
                    switch (command)
                    {

                        case "up":
                            currentRow++;
                            break;
                        case "down":
                            currentRow--;
                            break;
                        case "left":
                            currentCol++;
                            break;
                        case "right":
                            currentCol--;
                            break;

                        default:
                            break;
                    }

                    if (currentCol < 0)
                    {
                        currentCol = n - 1;
                    }
                    else if (currentCol == n)
                    {
                        currentCol = 0;
                    }
                    else if (currentRow < 0)
                    {
                        currentRow = n - 1;
                    }
                    else if (currentRow == n)
                    {
                        currentRow = 0;
                    }
                }
                else if (field[currentRow, currentCol] == 'F')
                {
                    isWon = true;
                    field[playerRow, playerCol] = '-';
                    field[currentRow, currentCol] = 'f';

                }

                if (isWon)
                {
                    break;
                }
                field[playerRow, playerCol] = '-';

                field[currentRow, currentCol] = 'f';


                playerRow = currentRow;
                playerCol = currentCol;
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }

        }

        private static int Movement(string command, int currentRow, int currentCol, int n)
        {
            switch (command)
            {

                case "up":
                    currentRow--;
                    break;
                case "down":
                    currentRow++;
                    break;
                case "left":
                    currentCol--;
                    break;
                case "right":
                    currentCol++;
                    break;

                default:
                    break;
            }

            if (currentCol < 0)
            {
                currentCol = n - 1;
            }
            else if (currentCol == n)
            {
                currentCol = 0;
            }
            else if (currentRow < 0)
            {
                currentRow = n - 1;
            }
            else if (currentRow == n)
            {
                currentRow = 0;
            }

            if (command == "up" || command == "down")
            {
                return currentRow;
            }
            else
            {
                return currentCol;
            }
        }
    }
}
