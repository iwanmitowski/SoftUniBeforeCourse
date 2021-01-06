using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine().ToLower();
            string input = Console.ReadLine();

            while (input.Contains(wordToRemove))
            {
                int index = input.IndexOf(wordToRemove);
                input = input.Remove(index, wordToRemove.Length);
                
            }
            Console.WriteLine(input);
        }
    }
}
