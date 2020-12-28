using System;
using System.Linq;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine(string.Join(" ",text.Reverse()));
        }
    }
}
