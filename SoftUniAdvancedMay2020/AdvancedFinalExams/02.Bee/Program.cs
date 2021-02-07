using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] teritory = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;

            int pollinatedFlowers = 0;

            for (int i = 0; i < n; i++)
            {
                string colsInput = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (colsInput[j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                    teritory[i, j] = colsInput[j];

                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                int currentRow = beeRow;
                int currentCol = beeCol;
                switch (input)
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

                if (currentRow < 0 || currentRow >= n || currentCol < 0 || currentCol >= n)
                {
                    teritory[beeRow, beeCol] = '.';

                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (teritory[currentRow, currentCol] == 'f')
                {
                    pollinatedFlowers++;
                    
                }
                if (teritory[currentRow, currentCol] == 'O')
                {
                    teritory[currentRow, currentCol] = '.';
                    switch (input)
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
                    if (teritory[currentRow, currentCol] == 'f')
                    {
                        pollinatedFlowers++;
                       
                    }
                    //B

                }
                teritory[currentRow, currentCol] = 'B';
                teritory[beeRow, beeCol] = '.';
                input = Console.ReadLine();

                beeRow = currentRow;
                beeCol = currentCol;

            }
            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(teritory[i, j]);
                }
                Console.WriteLine();
            }

        }




    }
}
