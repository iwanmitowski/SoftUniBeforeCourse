using System;

namespace _02.RecursiveFactorial
{
    class Program
    {
        static int Factorial(int num)
        {
            if (num==1)
            {
                return 1;
            }

            int fact = num * Factorial(num - 1);
            return fact;
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(num));
        }
    }
}
