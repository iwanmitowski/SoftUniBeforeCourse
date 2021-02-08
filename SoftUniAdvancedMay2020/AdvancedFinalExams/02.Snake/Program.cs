using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;

            int firstBRow = -1;
            int firstBCol = -1;

            int secondBRow = -1;
            int secondBCol = -1;

            int food = 0;
            bool isOut = false;


            for (int i = 0; i < n; i++)
            {
                string colsInput = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    field[i, j] = colsInput[j];
                    if (colsInput[j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                    if (colsInput[j] == 'B' && firstBRow == -1)
                    {
                        firstBRow = i;
                        firstBCol = j;
                    }
                    else if (colsInput[j] == 'B' && firstBRow != -1)
                    {
                        secondBRow = i;
                        secondBCol = j;
                    }
                }
            }

            while (food != 10)
            {
                string move = Console.ReadLine();

                int currentRow = snakeRow;
                int currentCol = snakeCol;

                switch (move)
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

                if (currentRow < 0 || currentRow == n || currentCol < 0 || currentCol == n)
                {
                    field[snakeRow, snakeCol] = '.';
                    isOut = true;
                    break;
                }

                if (field[currentRow, currentCol] == 'B')
                {
                    if (currentRow == firstBRow && currentCol == firstBCol)
                    {
                        currentRow = secondBRow;
                        currentCol = secondBCol;
                    }
                    else if (currentRow == secondBRow && firstBCol == secondBCol)
                    {
                        currentRow = firstBRow;
                        currentCol = firstBCol;
                    }
                    field[firstBRow, firstBCol] = '.';
                    field[secondBRow, secondBCol] = '.';

                }
                else if (field[currentRow, currentCol] == '*')
                {
                    food++;
                }

                field[snakeRow, snakeCol] = '.';
                field[currentRow, currentCol] = 'S';

                snakeRow = currentRow;
                snakeCol = currentCol;

            }

            if (isOut)
            {
                Console.WriteLine("Game over!");
            }
            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {food}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
