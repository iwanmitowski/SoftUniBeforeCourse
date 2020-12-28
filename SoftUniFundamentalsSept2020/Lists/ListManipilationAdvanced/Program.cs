using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulation
{
    class Program
    {
        static void Main(string[] args)
        {

            //https://www.youtube.com/watch?v=Z5GUHst-wS4&feature=emb_title
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isChanged = false;
            string[] input = Console.ReadLine().Split();

            while (input[0].ToLower() != "end")
            {
                switch (input[0].ToLower())
                {
                    case "add":
                        numbers.Add(int.Parse(input[1]));
                        isChanged = true;
                        break;
                    case "remove":
                        numbers.Remove(int.Parse(input[1]));
                        isChanged = true;
                        break;
                    case "removeat":
                        numbers.RemoveAt(int.Parse(input[1]));
                        isChanged = true;
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        isChanged = true;
                        break;

                        //Important!!!
                    case "contains":
                        Console.WriteLine(numbers.Contains(int.Parse(input[1])) ? "Yes" : "No such number");
                        break;

                    case "printeven":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                        break;
                    case "printodd":
                        Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                        break;
                    case "getsum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "filter":
                        switch (input[1])
                        {
                            case "<":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n < int.Parse(input[2]))));
                                break;
                            case "<=":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n <= int.Parse(input[2]))));
                                break;
                            case ">":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n > int.Parse(input[2]))));
                                break;
                            case ">=":
                                Console.WriteLine(string.Join(" ", numbers.Where(n => n >= int.Parse(input[2]))));
                                break;

                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine().Split();
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }

        }
    }
}
