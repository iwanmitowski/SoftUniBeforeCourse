using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>,int, List<int>> reverseAndExclude = (nums,n) =>
             {
                 List<int> result = new List<int>();

                 for (int i = nums.Count - 1; i >= 0; i--)
                 {
                     if (nums[i]%n!=0)
                     {
                         result.Add(nums[i]);
                     }
                 }


                 return result;
             };

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ",reverseAndExclude(numbers, n))); 
        }
    }
}
