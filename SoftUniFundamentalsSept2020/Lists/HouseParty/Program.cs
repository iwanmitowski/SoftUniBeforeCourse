using System;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string guestName = command[0];
                //not going
                if (command.Length>3)
                {
                    
                    if (guests.Contains(guestName))
                    {
                        guests.Remove(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is not in the list!");
                    }
                }
                //going
                else
                {
                    if (!guests.Contains(guestName))
                    {
                        guests.Add(guestName);
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} is already in the list!");
                    }
                }


            }
            Console.WriteLine(string.Join(Environment.NewLine,guests));
        }
    }
}
