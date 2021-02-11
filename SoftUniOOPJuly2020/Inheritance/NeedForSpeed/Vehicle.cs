using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower,double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kms)
        {
            double fuelLeft = this.Fuel - FuelConsumption * kms;
            if (fuelLeft>=0)
            {
                this.Fuel = fuelLeft;
            }
        }
    }
}
