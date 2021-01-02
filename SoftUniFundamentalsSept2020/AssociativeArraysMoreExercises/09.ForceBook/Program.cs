using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] commands = input.Split(" | ");

                    string forceSide = commands[0];
                    string forceUser = commands[1];

                    if (users.ContainsKey(forceUser) == false)
                    {
                        users.Add(forceUser, forceSide);
                    }
                }
                else if (input.Contains("->"))
                {
                    string[] commands = input.Split(" -> ");

                    string forceSide = commands[1];
                    string forceUser = commands[0];

                    if (users.ContainsKey(forceUser))
                    {
                        users[forceUser] = forceSide;
                    }
                    else
                    {
                        users.Add(forceUser, forceSide);
                    }
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var user in users.GroupBy(x => x.Value)
                .OrderByDescending(x => x.Count())
                .ThenBy(x=>x.Key))
            {
                Console.WriteLine($"Side: {user.Key}, Members: {user.Count()}");

                foreach (var member in user.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"! {member.Key}");
                }
            }



        }
    }
}
