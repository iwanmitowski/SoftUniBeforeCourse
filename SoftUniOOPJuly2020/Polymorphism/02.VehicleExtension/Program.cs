
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.VehicleExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            for (int i = 0; i < 3; i++)
            {
                string[] carInput = Console.ReadLine().Split();

                try
                {
                    vehicles.Add(CreateVehicle(carInput));
                }
                catch (FuelOutOfTankException fote)
                {
                    Console.WriteLine(fote.Message);
                    continue;
                }
                catch (NegativeFuelException nfe)
                {
                    Console.WriteLine(nfe.Message);
                }
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
                else if (type == "Bus")
                {
                    Bus currentBus = (Bus)vehicles.First(x => x.GetType().Name == "Bus");
                    PerformActivity(activity, currentBus, param);

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
                try
                {
                    vehicle.Refuel(param);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            else if (activity == "DriveEmpty")
            {
                (vehicle as Bus).DriveEmpty(param);
            }
        }
        public static IVehicle CreateVehicle(string[] carInput)
        {
            double vehicleFuelQuantity = double.Parse(carInput[1]);
            double vehicleFuelConsumption = double.Parse(carInput[2]);
            double vehicleTankCapacity = double.Parse(carInput[3]);

            if (carInput[0] == "Car")
            {
                IVehicle car = new Car(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);
                return car;

            }
            else if (carInput[0] == "Truck")
            {
                IVehicle truck = new Truck(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);
                return truck;

            }
            else
            {
                IVehicle bus = new Bus(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);

                return bus;
            }


        }
    }
}
