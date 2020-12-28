using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                double fuel = double.Parse(input[1]);
                double consumption = double.Parse(input[2]);

                Car car = new Car(model,fuel,consumption);
                cars.Add(car);

            }

            string[] command = Console.ReadLine().Split();
            while (command[0] !="End")
            {
                string model = command[1];
                int kms = int.Parse(command[2]);

                List<Car> currCar = cars.Where(x => x.Model == model).ToList();

                if (currCar[0].CanMove(currCar[0].Fuel, currCar[0].Consumption, kms))
                {
                    currCar[0].Fuel -= currCar[0].Consumption * kms;
                    currCar[0].TraveledDistance += kms;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                
                
                command = Console.ReadLine().Split();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
