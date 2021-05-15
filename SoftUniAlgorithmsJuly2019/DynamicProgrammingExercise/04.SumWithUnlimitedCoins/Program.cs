using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumWithUnlimitedCoins
{
    class Program
    {
        static int targetSum;
        static int[] coins;
        static int totalSums;
        static void Main(string[] args)
        {
            coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            targetSum = int.Parse(Console.ReadLine());


            CalculatePossibleSums(0, 0);

            Console.WriteLine(totalSums);
            
        }
        static void CalculatePossibleSums(int sum, int start)
        {
            if (sum == targetSum)
            {
                totalSums++;
                return;
            }
            if (sum > targetSum)
            {
                return;
            }

            for (int i = start; i < coins.Length; i++)
            {
                CalculatePossibleSums(sum + coins[i], i);
            }
        }
    }
}
