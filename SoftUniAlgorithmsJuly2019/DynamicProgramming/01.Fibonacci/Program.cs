using System;

namespace _01.Fibonacci
{
    class Program
    {
        static long[] memo;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            memo = new long[n+1];
            Console.WriteLine(Fib(n));
        }

        private static long Fib(int n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }

            if(n <= 2)
            {
                memo[n] = 1;
            }
            else
            {
                memo[n] = Fib(n - 2) + Fib(n - 1);
            }

            return memo[n];
        }
    }
}
