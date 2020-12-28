using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double factFirst = Factorial(num1);
            double factSec = Factorial(num2);

            double result = factFirst / factSec;
            Console.WriteLine($"{result:F2}");
        }

        static double Factorial(int number)
        {
            double factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

    }
}
