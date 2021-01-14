using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string name = input[0];
                double rarity = double.Parse(input[1]);

                if (!IsExistingPlant(name, plants))
                {
                    plants.Add(new Plant(name, rarity, new List<double>()));
                }
                else if (IsExistingPlant(name, plants))
                {
                    foreach (Plant plant in plants)
                    {
                        if (plant.Name == name)
                        {
                            plant.Rarity = rarity;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            string[] commands = Console.ReadLine().Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Exhibition")
            {
                if (commands.Contains("Rate")|| commands.Contains("Update")|| commands.Contains("Reset"))
                {
                    string activity = commands[0];
                    string name = commands[1];

                    if (activity == "Rate")
                    {
                        double rating = double.Parse(commands[2]);
                        foreach (Plant plant in plants)
                        {
                            if (plant.Name == name)
                            {
                                plant.Rating.Add(rating);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                        }
                    }
                    else if (activity == "Update")
                    {
                        double rarity = double.Parse(commands[2]);
                        foreach (Plant plant in plants)
                        {
                            if (plant.Name == name)
                            {
                                plant.Rarity = rarity;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                        }
                    }
                    else if (activity == "Reset")
                    {
                        foreach (Plant plant in plants)
                        {
                            if (plant.Name == name)
                            {
                                plant.Rating = new List<double>() { 0 };

                                break;
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
                


                commands = Console.ReadLine().Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant plant in plants.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.Rating.Average()))
            {
                Console.WriteLine(plant);
            }

        }

        static bool IsExistingPlant(string name, List<Plant> plants)
        {

            foreach (Plant plant in plants)
            {
                if (plant.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
    class Plant
    {
        public Plant(string name, double rarity, List<double> rating)
        {
            Name = name;
            Rarity = rarity;
            Rating = rating;
        }

        public string Name { get; set; }
        public double Rarity { get; set; }
        public List<double> Rating { get; set; }

        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {Rating.Average():f2}";
        }
    }

}
