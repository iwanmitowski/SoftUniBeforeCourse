using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Vehicle: IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumpution;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }

        public virtual double FuelConsumption
        {
            get { return fuelConsumpution; }
            set { fuelConsumpution = value; }
        }
        
        public virtual void Drive(double distance)
        {

            var canDrive = this.FuelQuantity >= this.FuelConsumption * distance;

            if (canDrive)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
