using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SumWithLimitedCoins
{
    class Program
    {
        static int targetSum;
        static int[] coins;
        static int totalSums;
        static List<int> currentCombination = new List<int>();
        static HashSet<string> combinations = new HashSet<string>();
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
                string combination = string.Join(" ",currentCombination.OrderBy(x=>x));

                if (combinations.Contains(combination))
                {
                    return;
                }

                combinations.Add(combination);
                totalSums++;

                return;
            }

            if (sum > targetSum)
            {
                return;
            }

            for (int i = start; i < coins.Length; i++)
            {
                currentCombination.Add(coins[i]);
                CalculatePossibleSums(sum + coins[i], i+1);
                currentCombination.Remove(coins[i]);
            }
        }
    }
}
