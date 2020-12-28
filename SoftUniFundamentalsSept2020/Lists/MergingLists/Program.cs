using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> numbers2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < Math.Min(numbers1.Count, numbers2.Count); i++)
            {
                result.Add(numbers1[i]);
                result.Add(numbers2[i]);

            }
            for (int i = Math.Min(numbers1.Count,numbers2.Count); i < Math.Max(numbers1.Count,numbers2.Count); i++)
            {
                if (numbers1.Count > numbers2.Count)
                {
                    result.Add(numbers1[i]);
                }
                else
                {
                    result.Add(numbers2[i]);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
