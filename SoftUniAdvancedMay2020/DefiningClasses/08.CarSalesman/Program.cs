using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInput = Console.ReadLine().Split();
                string model = engineInput[0];
                string power = engineInput[1];
                int displacement;
                string efficiency;

                if (engineInput.Length > 2)
                {
                    if (int.TryParse(engineInput[2], out displacement))
                    {
                        if (engineInput.Length == 4)
                        {
                            efficiency = engineInput[3];
                            Engine engine = new Engine(model, power, displacement, efficiency);
                            engines.Add(model, engine);

                        }
                        else if (engineInput.Length == 3)
                        {
                            Engine engine = new Engine(model, power, displacement);
                            engines.Add(model, engine);


                        }

                    }
                    else
                    {
                        efficiency = engineInput[2];
                        Engine engine = new Engine(model, power, efficiency);
                        engines.Add(model, engine);

                    }
                }
                else
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(model, engine);

                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carInput = Console.ReadLine().Split();
                string model = carInput[0];
                string engineModel = carInput[1];
                int weight;
                string color;
                if (carInput.Length > 2)
                {
                    if (int.TryParse(carInput[2], out weight))
                    {
                        if (carInput.Length == 4)
                        {
                            color = carInput[3];
                            Car car = new Car(model, engines[engineModel], weight, color);
                            cars.Add(car);
                        }
                        else if (carInput.Length == 3)
                        {
                            Car car = new Car(model, engines[engineModel], weight);
                            cars.Add(car);

                        }
                    }
                    else
                    {
                        color = carInput[2];
                        Car car = new Car(model, engines[engineModel], color);
                        cars.Add(car);

                    }
                }
                else
                {
                    Car car = new Car(model, engines[engineModel]);
                    cars.Add(car);


                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
