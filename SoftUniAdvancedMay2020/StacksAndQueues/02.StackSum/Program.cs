using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int sum = 0;

            string[] commands = Console.ReadLine().Split();
            while (commands[0].ToLower() != "end")
            {
                if (commands[0] == "add")
                {
                    numbers.Push(int.Parse(commands[1]));
                    numbers.Push(int.Parse(commands[2]));
                }
                else if (commands[0] == "remove")
                {
                    int count = int.Parse(commands[1]);
                    if (numbers.Count >= count )
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                            if (numbers.Count == 0)
                            {
                                break;
                            }
                        }
                    }

                }

                commands = Console.ReadLine().Split();
            }

            while (numbers.Count > 0)
            {
                sum += numbers.Pop();
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
