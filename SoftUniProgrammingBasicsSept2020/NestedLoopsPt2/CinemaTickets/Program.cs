using System;
using System.Threading.Channels;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {

            double ticketStudent = 0;
            double ticketStandard = 0;
            double ticketKid = 0;
            double ticketTotal = 0;
            double currentSlots = 0;



            while (true)
            {
                string movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    break;

                }
                double slots = int.Parse(Console.ReadLine());
                

                for (int i = 0; i < slots; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }
                    ticketTotal++;
                    currentSlots++;
                    switch (ticketType)
                    {
                        case "student":
                            ticketStudent++;
                            break;
                        case "standard":
                            ticketStandard++;
                            break;
                        case "kid":
                            ticketKid++;
                            break;

                        default:

                            break;
                    }

                }
                
                Console.WriteLine($"{movie} - {(double)(currentSlots / slots) * 100:f2}% full.");
                currentSlots = 0;
            }
            Console.WriteLine($"Total tickets: {ticketTotal}");
            Console.WriteLine($"{(ticketStudent / ticketTotal) * 100:f2}% student tickets.");
            Console.WriteLine($"{(ticketStandard / ticketTotal) * 100:f2}% standard tickets.");
            Console.WriteLine($"{(ticketKid / ticketTotal) * 100:f2}% kids tickets.");

        }
    }
}
