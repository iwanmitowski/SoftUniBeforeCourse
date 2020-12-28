using System;
using System.Threading.Channels;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int ticketStudent = 0;
            int ticketStandart = 0;
            int ticketKid = 0;
            int ticketTotal = 0;



            while (true)
            {
                string movie = Console.ReadLine();
                if (movie=="Finish")
                {
                    break;

                }
                int slots = int.Parse(Console.ReadLine());

                for (int i = 0; i < slots; i++)
                {
                    string ticketType = Console.ReadLine();
                    
                    ticketTotal++;
                    switch (ticketType)
                    {
                        case "student":
                            ticketStudent++;
                            break;
                        case "standart":
                            ticketStandart++;
                            break;
                        case "kid":
                            ticketKid++;
                            break;

                        default:
                        case "End":
                            break;
                    }
                }
                Console.WriteLine($"{movie} - % ");
                 
            }
        }
    }
}
