using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cont = input[0];
                string country = input[1];
                string city = input[2];

                if (continents.ContainsKey(cont)==false)
                {
                    continents.Add(cont, new Dictionary<string, List<string>>());
                    continents[cont].Add(country, new List<string> { city });
                }
                else
                {
                    if (continents[cont].ContainsKey(country))
                    {
                        continents[cont][country].Add(city);
                    }
                    else
                    {
                        continents[cont].Add(country, new List<string> { city });
                    }
                }

            }

            foreach (var cont in continents)
            {
                Console.WriteLine($"{cont.Key}:");
                foreach (var country in cont.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
            
        }
    }
}
