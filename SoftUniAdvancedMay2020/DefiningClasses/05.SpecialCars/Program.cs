using _04.CarEngineAndTires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.SpecialCars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tire> tires = new List<Tire>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string[] tiresInput = Console.ReadLine().Split();
            
            while (tiresInput[0] != "No")
            {
                double tirePressure = 0;

                for (int i = 0; i < tiresInput.Length; i++)
                {
                    if (i%2==0)
                    {
                        tirePressure += double.Parse(tiresInput[i]);
                    }
                }
                Tire tire = new Tire(tirePressure);
                tires.Add(tire);

                tiresInput = Console.ReadLine().Split();
            }

            string[] engineInput = Console.ReadLine().Split();

            while (engineInput[0]!="Engines")
            {
                int hp = int.Parse(engineInput[0]);
                double cubicCapacity = double.Parse(engineInput[1]);

                Engine engine = new Engine(hp, cubicCapacity);
                engines.Add(engine);

                engineInput = Console.ReadLine().Split();
            }

            string[] buildingCar = Console.ReadLine().Split();
            while (buildingCar[0]!="Show")
            {
                string make = buildingCar[0];
                string model = buildingCar[1];
                int year = int.Parse(buildingCar[2]);
                
                double fuelQuantity = double.Parse(buildingCar[3]);
                double fuelQConsumption = double.Parse(buildingCar[4]);
                int endingeIndex = int.Parse(buildingCar[5]);
                int tiresIndex = int.Parse(buildingCar[6]);
                
                cars.Add(new Car(make,model,year,fuelQuantity,fuelQConsumption,engines[endingeIndex],tires));

                buildingCar = Console.ReadLine().Split();
            }

            int counter = 0;
            foreach (Car car in cars)
            {
               
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires[counter].Pressure>=9 && car.Tires[counter].Pressure<=10)
                {
                    StringBuilder sb = new StringBuilder();

                    car.Drive(20);

                    sb.AppendLine($"Make: {car.Make}");
                    sb.AppendLine($"Model: {car.Model}");
                    sb.AppendLine($"Year: {car.Year.ToString()}");
                    sb.AppendLine($"HorsePowers: {car.Engine.HorsePower.ToString()}");
                    sb.AppendLine($"FuelQuantity: {car.FuelQuantity.ToString()}");

                    Console.Write(sb);
                }
            }
        }
    }
}
