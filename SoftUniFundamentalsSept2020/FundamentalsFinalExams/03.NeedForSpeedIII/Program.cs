using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|");

                string name = input[0];
                int miles = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                cars.Add(new Car(name, miles, fuel));
            }

            string[] commands = Console.ReadLine().Split(" : ");
            while (commands[0] != "Stop")
            {
                string action = commands[0];
                string name = commands[1];

                if (action == "Drive")
                {
                    int distance = int.Parse(commands[2]);
                    int fuel = int.Parse(commands[3]);

                    foreach (Car car in cars)
                    {
                        if (car.Name == name)
                        {
                            if (car.Fuel >= fuel)
                            {
                                car.Fuel -= fuel;
                                car.Miles += distance;
                                Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                                if (car.Miles >= 100000)
                                {
                                    Console.WriteLine($"Time to sell the {car.Name}!");
                                    cars.Remove(car);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Not enough fuel to make that ride");

                            }
                            break;
                        }

                    }
                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(commands[2]);
                    foreach (Car car in cars)
                    {
                        if (car.Name == name)
                        {
                            int currFuel = car.Fuel;
                            car.Fuel += fuel;
                            if (car.Fuel > 75)
                            {
                                car.Fuel = 75;
                                Console.WriteLine($"{car.Name} refueled with {car.Fuel - currFuel} liters");
                                
                            }
                            else
                            {
                                Console.WriteLine($"{car.Name} refueled with {fuel} liters");
                            }
                            break;

                        }


                    }
                }
                else if (action == "Revert")
                {
                    int distance = int.Parse(commands[2]);
                    foreach (Car car in cars)
                    {
                        if (car.Name == name)
                        {
                            car.Miles -= distance;
                            if (car.Miles > 10000)
                            {
                                Console.WriteLine($"{car.Name} mileage decreased by {distance} kilometers");
                            }
                            else if(car.Miles < 10000)
                            {
                                car.Miles = 10000;
                            }
                            break;
                        }

                    }

                }


                commands = Console.ReadLine().Split(" : ");

            }

            foreach (Car car in cars.OrderByDescending(x => x.Miles).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{car.Name} -> Mileage: {car.Miles} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }
    class Car
    {
        public Car(string name, int miles, int fuel)
        {
            Name = name;
            Miles = miles;
            Fuel = fuel;
        }

        public string Name { get; set; }

        public int Miles { get; set; }
        public int Fuel { get; set; }

    }

}
