using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ProcessorScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] taskCountInput = Console.ReadLine().Split().ToArray();
            int tasksCount = int.Parse(taskCountInput[1]);

            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= tasksCount; i++)
            {
                int[] taskTokens = Console.ReadLine()
                    .Split(new string[] { " - " },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int value = taskTokens[0];
                int deadline = taskTokens[1];

                tasks.Add(new Task(i, value, deadline));
            }

            int maxDeadline = tasks.OrderByDescending(x => x.Deadline).First().Deadline;

            List<Task> executed = new List<Task>();

            for (int i = 1; i <= maxDeadline; i++)
            {
                var task = tasks.Where(x => x.Deadline <= i+1).OrderBy(x=>x.Value).Last();

                tasks.Remove(task);

                executed.Add(task);
            }

            executed = executed.OrderBy(t => t.Deadline).ThenByDescending(t => t.Value).ToList();

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ",executed)}");

            int totalValue = executed.Sum(x => x.Value);

            Console.WriteLine($"Total value: {totalValue}");
        }
    }

    class Task
    {
        public Task(int number, int value, int deadline)
        {
            Number = number;
            Value = value;
            Deadline = deadline;
        }

        public int Number { get; }
        public int Value { get;}
        public int Deadline { get;}

        public override string ToString()
        {
            return this.Number.ToString();
        }
    }
}
