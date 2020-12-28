using System;

namespace SummerBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Pages, PagesPerHour, Days
            // TimeTotal=Pages/PagesPerHour
            // Hours=TimeTotal/Days
            int Pages = int.Parse(Console.ReadLine());
            double PagesPerHour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double TimeTotal = Pages / PagesPerHour;
            double Hours = TimeTotal / days;
            Console.WriteLine(Hours);
        }
    }
}
