using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class SportCar : Car
    {
        private const double SportCarFuelConsumption = 10;

        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => SportCarFuelConsumption;

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
