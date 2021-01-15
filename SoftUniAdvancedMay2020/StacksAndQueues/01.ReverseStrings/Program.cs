using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input.ToArray());

            string result = string.Empty;
            foreach (var c in stack)
            {
                result += c;
            }
            Console.WriteLine(result);
        }
    }
}
