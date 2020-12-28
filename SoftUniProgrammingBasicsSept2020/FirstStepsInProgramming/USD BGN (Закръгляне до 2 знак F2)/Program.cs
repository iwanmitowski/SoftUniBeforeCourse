using System;

namespace USD_BGN__Закръгляне_до_2_знак_F2_
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * 1.79549;
            Console.WriteLine($"{bgn:F2}");
           
        }
    }
}
