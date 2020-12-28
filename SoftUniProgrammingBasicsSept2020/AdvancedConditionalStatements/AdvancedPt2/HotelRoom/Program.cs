using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studio = 0;
            double apartment = 0;

            if (month == "May" || month=="October")
            {
                studio = 50;
                apartment = 65;
                if (nights>7 && nights<=13)
                {
                    studio -= studio * 0.05;
                    
                }
                else if (nights>14)
                {
                    studio -= studio * 0.3;
                    apartment -= apartment * 0.1;
                }

            }
            else if (month == "June" || month == "September")
            {
                studio = 75.20;
                apartment = 68.70;
                if (nights > 14)
                {
                    studio -= studio * 0.2;
                    apartment -= apartment * 0.1;
                }
            }
            else if (month == "July" || month == "August")
            {
                studio = 76;
                apartment = 77;
                if (nights > 14)
                {
                    
                    apartment -= apartment * 0.1;
                }
            }
            Console.WriteLine($"Apartment: {apartment*nights:f2} lv.");
            Console.WriteLine($"Studio: {studio * nights:f2} lv.");


        }
    }
}
