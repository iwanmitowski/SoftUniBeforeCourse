using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);
                cars.Add(model,new Car(model, fuelAmount, fuelConsumption));
            }

            string[] drivingInput = Console.ReadLine().Split();

            while (drivingInput[0]!="End")
            {
                string currCar = drivingInput[1];
                double kms = double.Parse(drivingInput[2]);
                Car currentCarr = cars[currCar];

                currentCarr.Drive(currentCarr, kms);

                drivingInput = Console.ReadLine().Split();
            }

            foreach ((string model, Car car) in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
