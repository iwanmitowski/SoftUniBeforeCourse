using System;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string currUser = input[i];
                if (IsValid(currUser))
                {
                    Console.WriteLine(currUser);
                }

            }
        }

        static bool IsValid(string username)
        {

            return username.Length >= 3 && username.Length < 16
                && (username.All(char.IsLetterOrDigit)
                || username.Contains("-")
                || username.Contains("_"))
                ;

        }
    }
}
