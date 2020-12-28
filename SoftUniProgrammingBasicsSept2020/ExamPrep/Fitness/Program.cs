using System;

namespace Fitness
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                double currentNUmber = 1.00/i;
                sum += currentNUmber;

            }
            Console.WriteLine(sum);
        }
    }
}
