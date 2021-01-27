using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isWithUppercaseLetter = str => char.IsUpper(str[0]);

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isWithUppercaseLetter)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,words));

        }
    }
}
