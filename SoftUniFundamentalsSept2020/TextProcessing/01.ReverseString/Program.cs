using System;
using System.Linq;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                char[] reversedWord = input.ToCharArray();
                Console.WriteLine($"{input} = {string.Join("",reversedWord.Reverse())} ");

                input = Console.ReadLine();
            }
        }
    }
}
