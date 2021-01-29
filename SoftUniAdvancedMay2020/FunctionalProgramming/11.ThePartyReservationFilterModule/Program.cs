using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();

            Func<string, string, bool> startsWith = (n, c) => n.StartsWith(c);
            Func<string, string, bool> endsWith = (n, c) => n.EndsWith(c);
            Func<string, string, bool> checkLength = (n, c) => n.Length == int.Parse(c);
            Func<string, string, bool> contains = (n, c) => n.Contains(c);


            string[] command = Console.ReadLine().Split(";");
            while (command[0] != "Print")
            {
                string action = command[0];
                if (action == "Add filter")
                {
                    filters.Add($"{command[1]};{command[2]}");
                }
                else
                {
                    filters.Remove($"{command[1]};{command[2]}");
                }

                command = Console.ReadLine().Split(";");
            }


            foreach (var filter in filters)
            {
                string[] filterArgs = filter.Split(";");
                string type = filterArgs[0];
                string parameter = filterArgs[1];

                switch (type)
                {
                    case "Starts with":
                        guests = guests.Where(x => !startsWith(x, parameter)).ToList();
                        break;
                    case "Ends with":
                        guests = guests.Where(x => !endsWith(x, parameter)).ToList();

                        break;
                    case "Length":
                        guests = guests.Where(x => !checkLength(x, parameter)).ToList();

                        break;
                    case "Contains":
                        guests = guests.Where(x => !contains(x, parameter)).ToList();

                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
