using System;
using System.Security;

namespace CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            string result = ReturingCharacters(firstChar,secondChar);

            Console.WriteLine(result);

        }


        static string ReturingCharacters(char firstChar,char secondChar)
        {
            string result = string.Empty;
            if (firstChar>secondChar)
            {
                char supportingChar = firstChar;
                firstChar = secondChar;
                secondChar = supportingChar;

                
            }
            for (int i = firstChar + 1; i < secondChar; i++)
            {
                result += (char)i + " ";

            }


            return result;
        }
    }
}
