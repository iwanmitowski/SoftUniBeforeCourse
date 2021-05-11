using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.EgiptianFraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split("/").Select(int.Parse).ToArray();

            int p = numbers[0];
            int q = numbers[1];

            Console.Write($"{p}/{q} = ");

            List<string> realNumbers = new List<string>();

            if (p>=q)
            {
                Console.WriteLine($"Error (fraction is equal to or greater than 1)");
                Environment.Exit(0);
            }

            if (q%p==0)
            {
                q = q / p;
               
                realNumbers.Add($"1/{q}");

                Console.WriteLine(string.Join(" + ", realNumbers));
                Environment.Exit(0);
            }

            while (true)
            {
                int denominator = (p + q) / p;

                realNumbers.Add($"1/{denominator}");

                p = p*denominator-q;
                q *=denominator;

                if (q % p == 0)
                {
                    q = q / p;
                   
                    realNumbers.Add($"1/{q}");
                    break;
                }
            }

            Console.WriteLine(string.Join(" + ", realNumbers));
        }
    }
}
