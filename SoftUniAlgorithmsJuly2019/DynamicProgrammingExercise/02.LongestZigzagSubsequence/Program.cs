using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.LongestZigzagSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] dp = new int[2, sequence.Length];
            int[,] prev = new int[2, sequence.Length];

            dp[0, 0] = 1;
            dp[1, 0] = 1;
            prev[0, 0] = -1;
            prev[1, 0] = -1;

            int maxResult = 0;
            int maxIndexRow = 0;
            int maxIndexCol = 0;

            for (int currentIndex = 1; currentIndex < sequence.Length; currentIndex++)
            {
                for (int prevIndex = 0; prevIndex < currentIndex; prevIndex++)
                {
                    int currentNumber = sequence[currentIndex];
                    int prevNumber = sequence[prevIndex];

                    if (currentNumber > prevNumber
                        && dp[0, currentIndex] < dp[1, prevIndex] + 1)
                    {
                        dp[0, currentIndex] = dp[1, prevIndex] + 1;
                        prev[0, currentIndex] = prevIndex;
                    }

                    if (currentNumber < prevNumber
                        && dp[1, currentIndex] < dp[0, prevIndex] + 1)
                    {
                        dp[1, currentIndex] = dp[0, prevIndex] + 1;
                        prev[1, currentIndex] = prevIndex;
                    }
                }

                if (dp[0, currentIndex] > maxResult)
                {
                    maxResult = dp[0, currentIndex];
                    maxIndexRow = 0;
                    maxIndexCol = currentIndex;
                }

                if (dp[1, currentIndex] > maxResult)
                {
                    maxResult = dp[1, currentIndex];
                    maxIndexRow = 1;
                    maxIndexCol = currentIndex;
                }
            }

            List<int> result = new();

            while (maxIndexCol>=0)
            {
                result.Add(sequence[maxIndexCol]);
                maxIndexCol = prev[maxIndexRow, maxIndexCol];

                if (maxIndexRow==1)
                {
                    maxIndexRow = 0;
                }
                else
                {
                    maxIndexRow = 1;
                }
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
