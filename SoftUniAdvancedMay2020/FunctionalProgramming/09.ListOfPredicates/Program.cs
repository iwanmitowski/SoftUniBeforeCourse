using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                result.Add(i);
            }

            Predicate<int> isDividing = n =>
            {
                
                bool canDivide = false;
                foreach (var divider in dividers)
                {
                    if (n % divider==0)
                    {
                        canDivide = true;
                    }
                    else
                    {
                        canDivide = false;
                        break;
                    }
                }
                return canDivide;
            };

           result = result
                .Where(x => isDividing(x))
                .ToList();

            Console.WriteLine(string.Join(" ",result));
        }


    }
}
