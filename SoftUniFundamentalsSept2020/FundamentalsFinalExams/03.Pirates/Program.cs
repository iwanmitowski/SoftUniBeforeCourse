using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Pirates
{


    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = new List<Town>();

            string[] cityInput = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);

            while (cityInput[0] != "Sail")
            {
                string name = cityInput[0];
                long citizens = long.Parse(cityInput[1]);
                int gold = int.Parse(cityInput[2]);

                if (IsExisting(towns, name))
                {
                    foreach (Town city in towns)
                    {
                        if (city.Name == name)
                        {
                            city.Citizens += citizens;
                            city.Gold += gold;
                        }
                    }


                }
                else
                {
                    Town town = new Town(name, citizens, gold);

                    towns.Add(town);

                }

                cityInput = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            string[] eventsInput = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            while (eventsInput[0] != "End")
            {
                string activity = string.Empty;
                string name = string.Empty;
                long citizens = 0;
                int gold = 0;

                if (eventsInput.Length == 3)
                {
                    activity = eventsInput[0];
                    name = eventsInput[1];
                    gold = int.Parse(eventsInput[2]);
                }
                else
                {
                    activity = eventsInput[0];
                    name = eventsInput[1];
                    citizens = long.Parse(eventsInput[2]);
                    gold = int.Parse(eventsInput[3]);
                }


                if (gold < 0)
                {
                    Console.WriteLine("Gold added cannot be a negative number!");
                    eventsInput = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (activity == "Plunder")
                {
                    Console.WriteLine($"{name} plundered! {gold} gold stolen, {citizens} citizens killed.");
                    foreach (Town town in towns)
                    {
                        if (town.Name == name)
                        {
                            town.Citizens -= citizens;
                            town.Gold -= gold;
                            if (town.Citizens <= 0 || town.Gold <= 0)
                            {
                                Console.WriteLine($"{town.Name} has been wiped off the map!");
                                towns.Remove(town);
                                break;
                            }
                        }
                    }
                }
                else if (activity == "Prosper")
                {
                    foreach (Town town in towns)
                    {
                        if (town.Name == name)
                        {

                            town.Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town.Name} now has {town.Gold} gold.");
                        }
                    }

                }

                eventsInput = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }
            if (towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                foreach (var town in towns.OrderByDescending(x => x.Gold).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{town.Name} -> Population: {town.Citizens} citizens, Gold: {town.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
        static bool IsExisting(List<Town> towns, string name)
        {
            foreach (Town town in towns)
            {
                if (town.Name == name)
                {
                    return true;
                }
            }
            return false;

        }
    }
    class Town
    {
        public Town(string name, long citizens, int gold)
        {
            Name = name;
            Citizens = citizens;
            Gold = gold;
        }

        public string Name { get; set; }
        public long Citizens { get; set; }
        public int Gold { get; set; }
    }

}
