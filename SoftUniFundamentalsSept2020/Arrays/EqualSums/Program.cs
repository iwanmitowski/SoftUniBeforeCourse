using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            bool areEqual = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int rightSum = 0;
                int leftSum = 0;
                int currentElement = arr[i];



                for (int j = i + 1; j < arr.Length; j++)
                {

                    rightSum += arr[j];


                }
                for (int k = i - 1; k >= 0; k--)
                {

                    leftSum += arr[k];

                }


                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    areEqual = true;
                    break;
                }

            }
            if (!areEqual)
            {
                Console.WriteLine("no");

            }
        }
    }
}
