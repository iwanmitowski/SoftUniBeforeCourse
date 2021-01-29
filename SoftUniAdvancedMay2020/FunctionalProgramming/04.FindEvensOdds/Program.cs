using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> predicate = num => num % 2 == 0;

            List<int> result = new List<int>();

            int[] startEnd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            if (command=="odd")
            {
                predicate = num => num % 2 != 0;
            }

            for (int i = startEnd[0] ; i <= startEnd[1]; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
