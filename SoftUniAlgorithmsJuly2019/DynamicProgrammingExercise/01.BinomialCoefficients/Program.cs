using System;

namespace _01.BinomialCoefficients
{
    class Program
    {
        static long[,] binoms;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            binoms = new long[n + 1, k + 1];

            long binom = Binomial(n, k);

            Console.WriteLine(binom);
        }

        private static long Binomial(int n, int k)
        {
            if (binoms[n,k]!=0)
            {
                return binoms[n, k];
            }

            if (k > n)
            {
                return 0;
            }

            if (k == n || k == 0)
            {
                binoms[n, k] = 1;
            }
            else
            {
                binoms[n, k] = Binomial(n - 1, k - 1) + Binomial(n - 1, k);
            }

            return binoms[n, k];

        }
    }
}
