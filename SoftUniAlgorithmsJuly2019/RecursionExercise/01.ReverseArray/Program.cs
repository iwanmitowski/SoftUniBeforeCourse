using System;
using System.Linq;

namespace _01.ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            ArrayReversing(arr, 0,arr.Length-1);

            Console.WriteLine(string.Join(" ",arr));
        }

        private static void ArrayReversing(int[] arr, int start ,int end)
        {
            if (start>= end)
            {
                return;
            }

            int startNum = arr[start];
            int endingNum = arr[end];

            arr[start] = endingNum;
            arr[end] = startNum;

            ArrayReversing(arr, start+1, end-1);
        }
    }
}
