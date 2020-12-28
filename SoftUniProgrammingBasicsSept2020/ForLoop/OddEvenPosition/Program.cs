using System;

namespace OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;

            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            double oddSum = 0;
            double evenSum = 0;

            for (int i = 1; i <= n; i++)
            {
                double number = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += number;
                    if (number > evenMax)
                    {
                        evenMax = number;
                    }
                    if (number < evenMin)
                    {
                        evenMin = number;
                    }

                }
                else
                {
                    oddSum += number;
                    if (number > oddMax)
                    {
                        oddMax = number;
                    }
                    if (number < oddMin)
                    {
                        oddMin = number;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddMin == double.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }

            if (oddMax == double.MinValue)
            {
                Console.WriteLine($"OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenMin == double.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            }

            if (evenMax == double.MinValue)
            {
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
            //if (n == 0)
            //{
            //    double number = 0;
            //    Console.WriteLine($"OddSum={number:f2},");
            //    Console.WriteLine("OddMin=No,");
            //    Console.WriteLine("OddMax=No,");
            //    Console.WriteLine($"EvenSum={number:f2}");
            //    Console.WriteLine("EvenMin=No,");
            //    Console.WriteLine("EvenMax=No");



            //}
        }
    }
}
