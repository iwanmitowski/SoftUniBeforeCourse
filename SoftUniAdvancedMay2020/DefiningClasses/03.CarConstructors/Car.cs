using System;
using System.Collections.Generic;
using System.Text;

namespace _03.CarConstructors
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

        public Car(string make, string model, int year,double fuelQantity , double fuelConsumption)
            :this(make,model,year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
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

        public void Drive(double distance)
        {
            double remainingFuel = FuelQuantity - (distance / 100) * FuelConsumption;
            if (remainingFuel > 0)
            {
                FuelQuantity -= remainingFuel;
            }
            else
            {
                System.Console.WriteLine("Not enough fuel to perfom this trip!");
            }

        }
    }

}

