using System;

namespace _02.LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            int[,] lcs = new int[first.Length+1, second.Length+1];

            for (int i = 1; i < first.Length+1; i++)
            {
                for (int j = 1; j < second.Length+1; j++)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            Console.WriteLine(lcs[first.Length,second.Length]);
        }
    }
}
