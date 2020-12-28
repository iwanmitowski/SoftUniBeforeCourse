using System;

namespace MultiplyEvenByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int sumEven = GetSumOfEvenDigits(input);
            int sumOdds = GetSumOfOddsDigits(input);

            int finalResult = sumOdds * sumEven;
            Console.WriteLine(finalResult);



        }

        static int GetSumOfEvenDigits(string input)
        {
            int sumEven = 0;
            int number = Math.Abs(int.Parse(input));
            string numberString = number.ToString();
            for (int i = 0; i < numberString.Length; i++)
            {
                int digit = int.Parse(numberString[i].ToString()); // !!!! TO STRING!
                if (digit % 2 == 0)
                {
                    sumEven += digit;

                }
            }
            return sumEven;
        }
        static int GetSumOfOddsDigits(string input)
        {
            int sumOdds = 0;
            int number = Math.Abs(int.Parse(input));
            string numberString = number.ToString();
            for (int i = 0; i < numberString.Length; i++)
            {
                int digit = int.Parse(numberString[i].ToString()); // !!!! TO STRING!
                if (digit % 2 != 0)
                {
                    sumOdds += digit;

                }
            }
            return sumOdds;
        }



    }
}
