using System;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] places = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[] input = Console.ReadLine()
                .Split();

            int cupidLastPosition = 0;

            while (input[0] != "Love!")
            {
                int length = int.Parse(input[1]);

                cupidLastPosition += length;

                if (cupidLastPosition >= 0 && cupidLastPosition < places.Length)
                {
                    places[cupidLastPosition] -= 2;
                }
                else
                {
                    cupidLastPosition = 0;
                    places[cupidLastPosition] -= 2;
                }

                if (places[cupidLastPosition] == 0)
                {
                    Console.WriteLine($"Place {cupidLastPosition} has Valentine's day.");
                }
                else if (places[cupidLastPosition] < 0)
                {
                    Console.WriteLine($"Place {cupidLastPosition} already had Valentine's day.");
                }

                input = Console.ReadLine()
                .Split();

            }

            Console.WriteLine($"Cupid's last position was {cupidLastPosition}.");

            int unsuccesCount = places.Count(x => x > 0);

            if (unsuccesCount == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {unsuccesCount} places.");
            }

        }
    }
}
