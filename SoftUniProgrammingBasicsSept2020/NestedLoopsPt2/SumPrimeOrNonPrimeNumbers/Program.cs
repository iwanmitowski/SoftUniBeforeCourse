using System;

namespace SumPrimeOrNonPrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int primeSum = 0;
            int nonPrimeSum = 0;
            bool isNonPrime = false;
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="stop")
                {
                    break;
                }
                int number = int.Parse(input);
                if (number<0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                int counter = 0;
                for (int i = 1; i <= number; i++)
                {
                    
                    if (number%i==0)
                    {

                        counter++;
                        
                    }

                }
                if (counter >= 1 && counter <= 2)
                {
                    primeSum += number;

                }
                else
                {
                    nonPrimeSum += number;
                }

            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
