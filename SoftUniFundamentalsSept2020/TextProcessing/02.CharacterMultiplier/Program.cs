using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string shortWord = input[0];
            string longWord = input[1];

            if (shortWord.Length>longWord.Length)
            {
                longWord = input[0];
                shortWord = input[1];
            }

            int sum = ReturnSum(shortWord, longWord);

            Console.WriteLine(sum);
        }

        static int ReturnSum(string shorter, string longer)
        {
            int sum = 0;
            for (int i = 0; i < shorter.Length; i++)
            {
                int product = shorter[i] * longer[i];
                sum += product;
            }

            for (int i = shorter.Length; i < longer.Length; i++)
            {
                sum += longer[i];
            }

            return sum;
        }
    }
}
