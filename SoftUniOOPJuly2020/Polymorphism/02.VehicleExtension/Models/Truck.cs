using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehicleExtension
{
    class Truck : Vehicle
    {
        private const double AirConditionConsumption = 1.6;
        private const double FuelExtraConsumption = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption+ AirConditionConsumption, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {

            if (liters <= 0)
            {
                throw new NegativeFuelException();
            }
            

            double currFuel = this.FuelQuantity;
            if (currFuel + liters > this.TankCapacity)
            {
                throw new FuelOutOfTankException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters * FuelExtraConsumption;


        }
    }
}
