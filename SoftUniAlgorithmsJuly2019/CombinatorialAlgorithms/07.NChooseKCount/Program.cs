using System;
using System.Numerics;

namespace _07.NChooseKCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger nFact = CalculateFactiorial(n);
            BigInteger kFact = CalculateFactiorial(k);
            BigInteger nkFact = CalculateFactiorial(n - k);
            BigInteger result = nFact / (nkFact * kFact);
            Console.WriteLine(result);

        } 

        private static BigInteger CalculateFactiorial(int num)
        {
            BigInteger result = 1;

            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
