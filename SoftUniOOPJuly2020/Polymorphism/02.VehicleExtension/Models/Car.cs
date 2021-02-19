using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehicleExtension
{
    class Car : Vehicle
    {
        private const double AirConditionConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + AirConditionConsumption, tankCapacity)
        {
        }

    }
}
