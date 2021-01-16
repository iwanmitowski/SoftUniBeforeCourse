using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];//push
            int s = input[1];//pop
            int x = input[2];//look for

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> numsStack = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                numsStack.Enqueue(numbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                numsStack.Dequeue();
            }

            if (numsStack.Count > 0)
            {
                if (numsStack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numsStack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
