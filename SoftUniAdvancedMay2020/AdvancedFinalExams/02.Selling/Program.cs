using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int money = 0;

            int playerRow = 0;
            int playerCol = 0;

            int firstPillarRow = -1;
            int firstPillarCol = -1;

            int secondPillarRow = -1;
            int secondPillarCol = -1;
            for (int i = 0; i < n; i++)
            {
                string colsInput = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (colsInput[j] == 'S')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                    if (colsInput[j] == 'O')
                    {
                        if (firstPillarRow == -1)
                        {
                            firstPillarRow = i;
                            firstPillarCol = j;
                        }
                        else
                        {
                            secondPillarRow = i;
                            secondPillarCol = j;
                        }
                    }
                    matrix[i, j] = colsInput[j];
                }
            }

            bool hasGoneOut = false;

            string move = Console.ReadLine();
            while (money < 50)
            {
                int currentRow = playerRow;
                int currentCol = playerCol;
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
                if (currentCol < 0 || currentCol == n || currentRow < 0 || currentRow == n)
                {
                    matrix[playerRow, playerCol] = '-';
                    hasGoneOut = true;
                    break;
                }
                matrix[playerRow, playerCol] = '-';
               
                if (char.IsDigit(matrix[currentRow, currentCol]))
                {
                    char value = (char)matrix[currentRow, currentCol];
                    money += int.Parse(value.ToString());
                    matrix[currentRow, currentCol] = 'S';
                    if (money>=50)
                    {
                        break;
                    }

                }

                if (matrix[currentRow, currentCol] == 'O')
                {
                    if (currentRow == firstPillarRow && currentCol == firstPillarCol)
                    {
                        currentRow = secondPillarRow;
                        currentCol = secondPillarCol;
                        matrix[firstPillarRow, firstPillarCol] = '-';
                        matrix[currentRow, currentCol] = 'S';
                    }
                    else if (currentRow == secondPillarRow && currentCol == secondPillarRow)
                    {
                        currentRow = firstPillarRow;
                        currentCol = firstPillarCol;
                        matrix[secondPillarRow, secondPillarCol] = '-';
                        matrix[currentRow, currentCol] = 'S';


                    }
                }



                move = Console.ReadLine();

                playerRow = currentRow;
                playerCol = currentCol;
            }

            if (hasGoneOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {money}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
