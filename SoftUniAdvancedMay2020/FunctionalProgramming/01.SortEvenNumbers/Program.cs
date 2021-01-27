using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                 .Split(", ")
                 .Select(x =>
                 {
                     int num = int.Parse(x);
                     return num;
                 })
                 .Where(x => x % 2 == 0)
                 .OrderBy(x => x)
                 .ToArray();
            Console.WriteLine(string.Join(", ", nums));




        }
    }
}
