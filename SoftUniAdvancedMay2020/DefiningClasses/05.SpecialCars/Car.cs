using System;
using System.Collections.Generic;
using System.Text;

namespace _04.CarEngineAndTires
{
    class Car
    {
        public Car()
        {

        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQantity, double fuelConsumption, Engine engine, List<Tire> tires
            )
            : this(make, model, year, fuelQantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }
        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private List<Tire> tires;

        public List<Tire> Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public void Drive(double distance)
        {
            double remainingFuel = FuelQuantity - (distance / 100) * FuelConsumption;
            if (remainingFuel >= 0)
            {
                FuelQuantity = remainingFuel;
            }
            else
            {
                System.Console.WriteLine("Not enough fuel to perfom this trip!");
            }


        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.AppendLine($"Fuel: {this.FuelQuantity:F1}");
            return sb.ToString();

        }


    }
}