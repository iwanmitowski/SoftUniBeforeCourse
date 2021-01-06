using System;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            string result = string.Empty; 

            foreach (var word in words)
            {
                int length = word.Length;

                for (int i = 0; i < length; i++)
                {
                    result += word;
                }
            }
            Console.WriteLine(result);
        }
    }
}
