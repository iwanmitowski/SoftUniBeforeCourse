using System;

namespace TopNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (ReturnTopNumbers(i))
                {
                    Console.WriteLine(i);
                }
                 
            }


            
        }

        static bool ReturnTopNumbers(int number)
        {
            
            int sumOfDigits = 0;
            string numberToString = number.ToString();
            bool hasOneOddDigit = false;
            for (int i = 0; i < numberToString.Length; i++)
            {
                
                sumOfDigits += int.Parse(numberToString[i].ToString());
                if (numberToString[i]%2==1)
                {
                    hasOneOddDigit = true;
                }

                
            }
            if (sumOfDigits % 8 == 0 && hasOneOddDigit)
            {
                
                
                return true;
            }

            
            return false;
        }
    }
}
