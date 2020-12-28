using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
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
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars.Where(x => x.CargoType == command).ToList();

                foreach (Car car in cars.Where(x=>x.CargoWeight<1000))
                {
                    Console.WriteLine(car);
                }
            }
            else if (command=="flamable")
            {
                cars = cars.Where(x => x.CargoType == command).ToList();
                foreach (Car car in cars.Where(x => x.EnginePower > 250))
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
