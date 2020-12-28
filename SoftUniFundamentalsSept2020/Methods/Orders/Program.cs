using System;
using System.Diagnostics.CodeAnalysis;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int numberOfProcudct = int.Parse(Console.ReadLine());
            double totalPrice = CalculatingTotalPrice(product, numberOfProcudct);
            Console.WriteLine($"{totalPrice:f2}");
        }

        static double CalculatingTotalPrice(string type, int number)
        {
            double sum = 0;

            double coffee = 1.5;
            double water = 1.00;
            double coke = 1.40;
            double snacks = 2.0;

            if (type=="coffee")
            {
                sum = coffee * number;
            }
            else if (type=="coke")
            {
                sum = coke * number;
            }
            else if (type == "water")
            {
                sum = water * number;
            }
            else if (type == "snacks")
            {
                sum = snacks * number;
            }


            return sum;
        }
    }
}
