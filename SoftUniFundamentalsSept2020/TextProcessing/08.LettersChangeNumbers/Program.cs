using System;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            double result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string currSeq = input[i];
                char firstLetter = currSeq[0];
                char lastLetter = currSeq[currSeq.Length-1];

                double numberPart = double.Parse(currSeq.Substring(1, currSeq.Length - 2));

                int positionFirstLetter = alphabet.IndexOf(char.ToUpper(firstLetter));
                int positionLastLetter = alphabet.IndexOf(char.ToUpper(lastLetter));

                if (firstLetter==char.ToUpper(firstLetter))
                {
                    result += numberPart / positionFirstLetter;
                }
                else
                {
                    result += numberPart * positionFirstLetter;
                }

                if (lastLetter==char.ToUpper(lastLetter))
                {
                    result -= positionLastLetter;
                }
                else
                {
                    result += positionLastLetter;
                }

            }
            Console.WriteLine($"{result:f2}");

        }
    }
}
