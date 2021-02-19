using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehicleExtension
{
    public class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumpution;
        private double tankCapacity;


        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;

                }
                else
                {
                    fuelQuantity = value;
                }

            }
        }

        public virtual double FuelConsumption
        {
            get { return fuelConsumpution; }
            set { fuelConsumpution = value; }
        }
        public double TankCapacity
        {
            get { return tankCapacity; }
            set
            {
                if (value <= 0)
                {
                    throw new NegativeFuelException();
                }
                tankCapacity = value;
            }
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
            if (liters <= 0)
            {
                throw new NegativeFuelException();
            }
            double currFuel = this.fuelQuantity;
            if (currFuel + liters > this.TankCapacity)
            {
                throw new FuelOutOfTankException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
