using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNum = nums =>
             {
                 int min = int.MaxValue;
                 foreach (var num in nums)
                 {
                     if (num<min)
                     {
                         min = num;
                     }
                 }
                 return min;
             };

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(minNum(nums));

        }
    }
}
