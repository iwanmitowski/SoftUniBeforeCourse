using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<int> queue = new Queue<int>(input.Split().Select(int.Parse).ToArray());
            List<int> numbers = new List<int>();

            while (queue.Count>0)
            {
                int number = queue.Dequeue();
                if (number % 2==0)
                {
                    numbers.Add(number);
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
