using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehicleExtension
{
    class Bus : Vehicle
    {
        private const double AirConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption+AirConditionConsumption, tankCapacity)
        {
        }

        public void DriveEmpty(double distance)
        {
            this.FuelConsumption -= AirConditionConsumption;
            base.Drive(distance);
        }
    }
}
