using System;
using System.Text;

namespace _05.DigitsLettersOther
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others = new StringBuilder();

            foreach (var c in input)
            {
                if (char.IsDigit(c))
                {
                    digits.Append(c);
                }
                else if (char.IsLetter(c))
                {
                    letters.Append(c);
                }
                else
                {
                    others.Append(c);
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);

        }
    }
}
