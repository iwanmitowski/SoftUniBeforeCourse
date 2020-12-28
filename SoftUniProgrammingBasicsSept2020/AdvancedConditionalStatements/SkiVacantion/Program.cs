using System;
using System.Net.Http.Headers;

namespace SkiVacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();

            int nights = days - 1;

            double totalPrice = 0.00;
            switch (roomType)
            {
                case "room for one person":
                    totalPrice = nights * 18.00;
                    if (rating=="positive")
                    {
                        totalPrice += totalPrice * 0.25;
                    }
                    else if (rating == "negative")
                    {
                        totalPrice -= totalPrice * 0.1;
                    }
                    Console.WriteLine($"{totalPrice:f2}");
                    break;
                case "apartment":
                    totalPrice = nights * 25.00;
                    if (days<10)
                    {
                        totalPrice -= totalPrice * 0.3;
                    }
                    else if (days>=10 && days<=15)
                    {
                        totalPrice -= totalPrice * 0.35;
                    }
                    else if (days>15)
                    {
                        totalPrice -= totalPrice * 0.5;
                    }
                    if (rating == "positive")
                    {
                        totalPrice += totalPrice * 0.25;
                    }
                    else if (rating == "negative")
                    {
                        totalPrice -= totalPrice * 0.1;
                    }
                    Console.WriteLine($"{totalPrice:f2}");
                    break;
                case "president apartment":
                    totalPrice = nights * 35.00;
                    if (days < 10)
                    {
                        totalPrice -= totalPrice * 0.1;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        totalPrice -= totalPrice * 0.15;
                    }
                    else if (days > 15)
                    {
                        totalPrice -= totalPrice * 0.2;
                    }
                    if (rating == "positive")
                    {
                        totalPrice += totalPrice * 0.25;
                    }
                    else if (rating == "negative")
                    {
                        totalPrice -= totalPrice * 0.1;
                    }
                    Console.WriteLine($"{totalPrice:f2}");
                    break;
                default:
                    break;
            }
        }
    }
}
