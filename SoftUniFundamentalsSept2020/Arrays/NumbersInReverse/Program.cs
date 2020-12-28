using System;
using System.Linq;

namespace NumbersInReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());

            }
            //for (int i = n - 1; i >= 0; i--)
            //{
            //    Console.Write($"{numbers[i]} ");
            //}

            Console.WriteLine(string.Join(" ",numbers.Reverse())); // РАЗДЕЛИТЕЛ ,и масивът



        }
    }
}
