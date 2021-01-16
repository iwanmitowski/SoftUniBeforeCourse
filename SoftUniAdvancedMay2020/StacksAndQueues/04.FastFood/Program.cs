using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(input);
            int biggestOrder = orders.Max();

            while (orders.Count>0)
            {
                int currentOrder = orders.Peek();
                if (quantity<currentOrder)
                {
                    break;
                }
                quantity -= currentOrder;
                orders.Dequeue();

            }
            Console.WriteLine(biggestOrder);
            if (orders.Count>0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
