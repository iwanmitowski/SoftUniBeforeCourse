using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(Car car,double kms)
        {
            double currFuel = car.FuelAmount;
            double neededFuel = car.FuelConsumptionPerKilometer * kms;
            if (currFuel - neededFuel >= 0)
            {
                car.TravelledDistance += kms;
                car.FuelAmount -= neededFuel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
