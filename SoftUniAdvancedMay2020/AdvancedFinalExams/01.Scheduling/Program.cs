using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            int valueOfTask = int.Parse(Console.ReadLine());

            int currentTask = tasks.Peek();
            int currentThread = threads.Peek();

            while (true)
            {
                if (currentTask==valueOfTask)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                    break;
                }
                if (currentTask<=currentThread)
                {
                    tasks.Pop();
                    threads.Dequeue();
                    currentTask = tasks.Peek();
                    currentThread = threads.Peek();
                }
                else if (currentTask>currentThread)
                {
                    threads.Dequeue();
                    currentThread = threads.Peek();
                }

            }

            Console.WriteLine(string.Join(" ",threads));
        }
    }
}
