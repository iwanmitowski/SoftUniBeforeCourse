using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guestList = new HashSet<string>();
            HashSet<string> vipGuestList = new HashSet<string>();

            string input = Console.ReadLine();


            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuestList.Add(input);
                }
                else
                {
                    guestList.Add(input);
                }
                
                input = Console.ReadLine();
            }


            input = Console.ReadLine();


            while (input != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuestList.Remove(input);
                }
                else
                {
                    guestList.Remove(input);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count+vipGuestList.Count);

            PrintingGuests(vipGuestList);
            PrintingGuests(guestList);
        }

        static void PrintingGuests(HashSet<string> guests)
        {
            foreach (var member in guests)
            {
                Console.WriteLine(member);
            }
        }
    }
}
