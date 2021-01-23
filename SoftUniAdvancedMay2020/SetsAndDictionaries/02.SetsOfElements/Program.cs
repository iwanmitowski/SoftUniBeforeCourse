using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstLength = input[0];
            int secondLength = input[1];
            HashSet<string> a = new HashSet<string>();
            HashSet<string> b = new HashSet<string>();



            for (int i = 0; i < firstLength; i++)
            {
                a.Add(Console.ReadLine());
            }
            for (int i = 0; i < secondLength; i++)
            {
                b.Add(Console.ReadLine());
            }
            a.IntersectWith(b);
            Console.WriteLine(string.Join(" ",a ));
        }
    }
}
