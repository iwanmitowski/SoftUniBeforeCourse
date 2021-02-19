using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }


        void Drive(double distance);

        void Refuel(double fuel);
    }
}
