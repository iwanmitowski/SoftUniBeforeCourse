using System;

namespace MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = MathPower(number, power);
            Console.WriteLine(result);
        }

        static double MathPower(double number, int power)
        {
            double result = 0d;

            result = Math.Pow(number, power);

            return result;
        }
    }
}
