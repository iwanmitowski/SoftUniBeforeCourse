using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class Car : Vehicle
    {
        private const double DefaultCarFuelConsumption = 3;

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultCarFuelConsumption;
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
