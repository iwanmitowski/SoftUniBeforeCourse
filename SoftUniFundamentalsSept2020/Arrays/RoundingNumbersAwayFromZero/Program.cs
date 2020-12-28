using System;
using System.Linq;

namespace RoundingNumbersAwayFromZero
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] rowOfNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < rowOfNumbers.Length; i++)
            {
                if (rowOfNumbers[i]==0)
                {
                    rowOfNumbers[i]=0;
                }
                else
                {
                    Console.WriteLine($"{rowOfNumbers[i]} => {Math.Round(rowOfNumbers[i], MidpointRounding.AwayFromZero)}");
                }
               
            }

        }


    }
}
