using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RodCutting
{
    class Program
    {
        static int[] prices;
        static int[] memo;
        static int[] pipes;
        static void Main(string[] args)
        {
            prices = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int pipeLength = int.Parse(Console.ReadLine());

            memo = new int[pipeLength + 1];
            pipes = new int[pipeLength + 1];

            Console.WriteLine(CutRod(pipeLength));

            while (pipeLength != 0)
            {
                Console.Write($"{pipes[pipeLength]} ");
                pipeLength -= pipes[pipeLength];
            }
        }

        private static int CutRod(int pipeLength)
        {
            if (memo[pipeLength] != 0)
            {
                return memo[pipeLength];
            }

            int maxPrice = 0;

            for (int i = 1; i <= pipeLength; i++)
            {
                int currentPrice = Math.Max(prices[i] + CutRod(pipeLength - i), maxPrice);

                if (currentPrice > maxPrice)
                {
                    maxPrice = currentPrice;
                    pipes[pipeLength] = i;
                }
            }

            memo[pipeLength] = maxPrice;
            
            return maxPrice;
        }
    }
}
