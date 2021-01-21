using System;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] moves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[,] field = new string[size, size];

            int startingRow = 0;
            int startingCol = 0;

            int startingCoal = 0;

            for (int i = 0; i < size; i++)
            {
                string[] fieldCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size; j++)
                {
                    if (fieldCols[j] == "s")
                    {
                        startingRow = i;
                        startingCol = j;
                    }
                    else if (fieldCols[j]=="c")
                    {
                        startingCoal++;
                    }

                    field[i, j] = fieldCols[j];
                }
            }

            int playerCoal = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                int currentPlayerRow = startingRow;
                int currentPlayerCol = startingCol;

                int temp = 0;
                switch (moves[i])
                {
                    case "up":

                        temp = currentPlayerRow;
                        if (--temp>= 0)
                        {
                            currentPlayerRow--;
                        }
                        else
                        {
                            continue;
                        }

                        break;
                    case "down":

                        temp = currentPlayerRow;
                        if (++temp < size)
                        {
                            currentPlayerRow++;
                        }
                        else
                        {
                            continue;
                        }

                        break;
                    case "left":

                        temp = currentPlayerCol;
                        if (--temp>=0)
                        {
                            currentPlayerCol--;
                        }
                        else
                        {
                            continue;
                        }

                        break;
                    case "right":

                        temp = currentPlayerCol;
                        if (++temp<size)
                        {
                            currentPlayerCol++;
                        }
                        else
                        {
                            continue;
                        }
                       
                        break;

                    default:
                        break;
                }

                if (field[currentPlayerRow, currentPlayerCol] == "e")
                {
                    Console.WriteLine($"Game over! ({currentPlayerRow}, {currentPlayerCol})");
                    Environment.Exit(0);
                }
                else if (field[currentPlayerRow, currentPlayerCol] == "c")
                {
                    playerCoal++;
                    if (playerCoal == startingCoal)
                    {
                        Console.WriteLine($"You collected all coals! ({currentPlayerRow}, {currentPlayerCol})");
                        Environment.Exit(0);
                    }
                    
                }

                field[currentPlayerRow, currentPlayerCol] = "s";
                field[startingRow, startingCol] = "*";

                startingRow = currentPlayerRow;
                startingCol = currentPlayerCol;



            }

            Console.WriteLine($"{startingCoal-playerCoal} coals left. ({startingRow}, {startingCol})");

           

        }
    }
}
