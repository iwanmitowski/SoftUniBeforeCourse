using System;

namespace _03.BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            int numberToFind = 1;

            Console.WriteLine(IndexOf(arr, numberToFind)); 
        }

        private static int IndexOf(int[] arr, int numberToFind)
        {
            int lo = 0;
            int hi = arr.Length - 1;

            while (lo<=hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (numberToFind < arr[mid])
                {
                    hi = mid - 1;
                }
                else if (numberToFind>arr[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }
    }
}
