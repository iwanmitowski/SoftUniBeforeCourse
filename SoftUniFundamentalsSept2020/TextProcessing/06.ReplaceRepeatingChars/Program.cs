using System;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            string result = string.Empty;

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i]!= input[i+1])
                {
                    result += input[i];
                }
            }
            char lastDigit = input[input.Length - 1];
            result += lastDigit;
            Console.WriteLine(result);
        }
    }
}
