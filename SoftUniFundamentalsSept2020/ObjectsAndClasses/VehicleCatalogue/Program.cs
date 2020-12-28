using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("/");
            List<Car> Cars = new List<Car>();
            List<Truck> Trucks = new List<Truck>();
            

            

            while (input[0] != "end")
            {
                string vehicleType = input[0];
                string brand = input[1];
                string model = input[2];
                int powerOrWeight = int.Parse(input[3]);
                

                if (vehicleType == "Car")
                {
                    Car car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = powerOrWeight;
                    Cars.Add(car);
                }
                else if (vehicleType == "Truck")
                {
                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = powerOrWeight;
                    Trucks.Add(truck);
                }



                input = Console.ReadLine().Split("/");
            }
            List<Car> SortedCars = new List<Car>(Cars.OrderBy(x=> x.Brand));
            List<Truck> SortedTrucks = new List<Truck>(Trucks.OrderBy(x => x.Brand));



            if (SortedCars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in SortedCars)
                {

                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (SortedTrucks.Count > 0)
            {
                foreach (Truck truck in SortedTrucks)
                {
                    Console.WriteLine("Trucks:");
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
