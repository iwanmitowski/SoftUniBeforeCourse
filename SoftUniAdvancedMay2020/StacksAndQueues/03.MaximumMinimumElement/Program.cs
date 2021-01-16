using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "1")
                {
                    numbers.Push(int.Parse(input[1]));
                }
                else if (input[0] == "2")
                {
                    if (numbers.Any())
                    {
                        numbers.Pop();
                    }
                }
                else if (input[0] == "3")
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Max());
                    }

                }
                else if (input[0] == "4")
                {
                    if (numbers.Any())
                    {
                        Console.WriteLine(numbers.Min());
                    }

                }

            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
