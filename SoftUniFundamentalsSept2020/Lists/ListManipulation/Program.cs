using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine().Split();

            while(input[0].ToLower()!="end")
            {
                switch (input[0].ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(input[1]));
                        break;
                    case "remove":
                        numbers.Remove(int.Parse(input[1]));
                        break;
                    case "removeat":
                        numbers.RemoveAt(int.Parse(input[1]));
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        break;


                    default:
                        break;
                }

                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
