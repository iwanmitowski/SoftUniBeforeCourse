using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfTheGarden = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = sizeOfTheGarden[0];
            int m = sizeOfTheGarden[1];

            int[,] garden = new int[n, m];

            List<string> flowers = new List<string>();

            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] givenCoords = input.Split().Select(int.Parse).ToArray();
                if (givenCoords[0]<0||givenCoords[0]>=n ||givenCoords[1]<0||givenCoords[1]>m)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                flowers.Add(input);

                input = Console.ReadLine();
            }



            foreach (var seed in flowers)
            {
                int[] seedPos = seed.Split().Select(int.Parse).ToArray();
                int seedRow = seedPos[0];
                int seedCol = seedPos[1];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (i == seedRow && j == seedCol)
                        {
                            for (int k = 0; k < n; k++)
                            {
                                
                                garden[k, seedCol]++;
                            }
                            for (int l = 0; l < m; l++)
                            {
                                if (l == seedRow)
                                {
                                    continue;
                                }
                                garden[seedRow, l]++;
                            }
                        }
                    }

                }

            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }



        }
    }
}
