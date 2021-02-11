using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        override public double FuelConsumption => DefaultFuelConsumption;
        //public override void Drive(double kms)
        //{
        //    double fuelLeft = this.Fuel - FuelConsumption * kms;
        //    if (fuelLeft >= 0)
        //    {
        //        this.Fuel = fuelLeft;
        //    }
        //}
    }
}
