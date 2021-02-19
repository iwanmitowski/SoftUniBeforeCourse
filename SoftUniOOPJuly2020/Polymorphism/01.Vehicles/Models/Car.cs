using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    class Car : Vehicle
    {
        private const double AirConditionConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + AirConditionConsumption)
        {
        }

    }
}
