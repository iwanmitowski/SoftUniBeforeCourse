using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            string[] input = Console.ReadLine().Split();

            while (input[0]!="End")
            {
                string type = input[0];
                string model = input[1];
                string color = input[2];
                int hp = int.Parse(input[3]);

                Vehicle vehicle = new Vehicle(type,model,color,hp);
                catalogue.Add(vehicle);
                input = Console.ReadLine().Split();
            }

            

            string command = Console.ReadLine();
            while (command!="Close the Catalogue")
            {
                string model = command;
                Vehicle printCar = catalogue.First(x => x.Model == model);

                Console.WriteLine(printCar);

                command = Console.ReadLine();
            }

            List<Vehicle> onlyCars = catalogue.Where(x => x.Type == "car").ToList();
            List<Vehicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();

           


            double carsHp = onlyCars.Select(x => x.HorsePower).Average();
            double trucksHp = onlyTrucks.Select(x => x.HorsePower).Average();

            Console.WriteLine($"Cars have average horsepower of: {carsHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksHp:f2}.");

        }
    }
}
