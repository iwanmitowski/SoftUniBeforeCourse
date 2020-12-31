using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToList();

            int count = 3;

            if (nums.Count < 3)
            {
                count = nums.Count;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write(nums[i] + " ");
            }

        }
    }
}
