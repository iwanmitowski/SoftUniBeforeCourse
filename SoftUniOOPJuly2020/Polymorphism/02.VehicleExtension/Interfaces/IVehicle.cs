using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehicleExtension
{
    interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }
        
        double TankCapacity { get; }

        void Drive(double distance);

        void Refuel(double fuel);
    }
}
