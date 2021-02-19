using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    class Truck : Vehicle
    {
        private const double AirConditionConsumption = 1.6;
        private const double FuelExtraConsumption = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption+ AirConditionConsumption)
        {
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters*FuelExtraConsumption ;
        }
    }
}
