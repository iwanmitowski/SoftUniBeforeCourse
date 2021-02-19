using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            for (int i = 0; i < 2; i++)
            {
                string[] carInput = Console.ReadLine().Split();

                vehicles.Add(CreateVehicle(carInput));
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] action = Console.ReadLine().Split();

                string activity = action[0];
                string type = action[1];
                double param = double.Parse(action[2]);

                if (type == "Car")
                {
                    Car currentCar = (Car)vehicles.First(x => x.GetType().Name == "Car");
                    PerformActivity(activity, currentCar, param);
                }
                else if (type == "Truck")
                {
                    Truck currentTruck = (Truck)vehicles.First(x => x.GetType().Name == "Truck");
                    PerformActivity(activity, currentTruck, param);
                }
            }

            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

        }
        public static void PerformActivity(string activity, IVehicle vehicle, double param)
        {
            if (activity == "Drive")
            {
                vehicle.Drive(param);
            }
            else if (activity == "Refuel")
            {
                vehicle.Refuel(param);
            }
        }
        public static IVehicle CreateVehicle(string[] carInput)
        {
            double vehicleFuelQuantity = double.Parse(carInput[1]);
            double vehicleFuelConsumption = double.Parse(carInput[2]);

            if (carInput[0] == "Car")
            {
                return new Car(vehicleFuelQuantity, vehicleFuelConsumption);

            }

            return new Truck(vehicleFuelQuantity, vehicleFuelConsumption);

        }
    }
}
