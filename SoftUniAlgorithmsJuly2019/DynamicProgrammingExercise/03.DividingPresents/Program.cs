using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.DividingPresents
{
    class Program
    {
        static int[] presents;
        static int[] indexes;
        static void Main(string[] args)
        {
            presents = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int total = presents.Sum();

            indexes = new int[total + 1];

            for (int i = 1; i < total + 1; i++)
            {
                indexes[i] = -1;
            }


            for (int i = 0; i < presents.Length; i++)
            {
                for (int j = total; j >= 0; j--)
                {
                    if (indexes[j] != -1 && indexes[j + presents[i]] == -1)
                    {
                        indexes[j + presents[i]] = i;
                    }
                }
            }

            int half = total / 2;

            for (int i = half; i >= 0; i--)
            {
                if (indexes[i] != -1)
                {
                    int bobShare = total - i;
                    int alanShare = i;
                    int difference = bobShare - alanShare;

                    Console.WriteLine($"Difference: {difference}");
                    Console.WriteLine($"Alan:{alanShare} Bob:{bobShare}");
                    Console.WriteLine($"Alan takes: {GetAlanPresents(alanShare)}");
                    Console.WriteLine($"Bob takes the rest.");
                    break;
                }
            }
        }

        private static string GetAlanPresents(int alanShare)
        {
            StringBuilder sb = new StringBuilder();

            while (alanShare!=0)
            {
                int currentPressent = presents[indexes[alanShare]];
                sb.Append($"{currentPressent} ");
                alanShare -= currentPressent;
            }

            return sb.ToString().Trim();
        }
    }
}
