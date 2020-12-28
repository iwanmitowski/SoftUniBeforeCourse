using System;

namespace MIddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string result = ReturnMiddlePartOfTheString(input);
            Console.WriteLine(result);
        }

        static string ReturnMiddlePartOfTheString(string input)
        {
            string result = string.Empty;

            if (input.Length%2==0)
            {
                result = input.Substring((input.Length / 2) - 1, 2);
            }
            else
            {
                result = input.Substring((input.Length / 2), 1);
            }
            

            return result;
        }


    }
}
