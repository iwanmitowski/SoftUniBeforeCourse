using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static int Sum(int[] arr,int index)
        {
            if (index==arr.Length)
            {
                return 0;
            }

            int sum = arr[index] + Sum(arr,index+1);

            return sum;

        }
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Sum(arr, 0)); 
        }
    }
}
