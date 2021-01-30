using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
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
                if (input.Length > 13)
                {
                    continue;
                }
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tirePressure1 = double.Parse(input[5]);
                int tireAge1 = int.Parse(input[6]);
                double tirePressure2 = double.Parse(input[7]);
                int tireAge2 = int.Parse(input[8]);
                double tirePressure3 = double.Parse(input[9]);
                int tireAge3 = int.Parse(input[10]);
                double tirePressure4 = double.Parse(input[11]);
                int tireAge4 = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire tires1 = new Tire(tireAge1, tirePressure1);
                Tire tires2 = new Tire(tireAge2, tirePressure2);
                Tire tires3 = new Tire(tireAge3, tirePressure3);
                Tire tires4 = new Tire(tireAge4, tirePressure4);
                List<Tire> tires = new List<Tire>();

                tires.Add(tires1);
                tires.Add(tires2);
                tires.Add(tires3);
                tires.Add(tires4);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string conditionCargo = Console.ReadLine();

            if (conditionCargo == "fragile")
            {
                cars.Where(c => c.Cargo.CargoType == "fragile")
                    .Where(c => c.Tires.Any(t => t.TirePressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));


            }
            else if (conditionCargo == "flamable")
            {
                cars.Where(c => c.Cargo.CargoType == "flamable")
                    .Where(c => c.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }


        }
    }
}
