using System;
using System.Collections.Generic;
using System.Text;

namespace _03.SpeedRacing
{
    class Car
    {
        public Car(string model, double fuel, double consumption)
        {
            Model = model;
            Fuel = fuel;
            Consumption = consumption;
        }

        public string Model { get; set; }
        public double Fuel { get; set; }
        public double Consumption { get; set; }
        public int TraveledDistance { get; set; }

        public bool CanMove(double fuel, double consumption, int kms)
        {
            if (fuel>=consumption*kms)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Model} {Fuel:f2} {TraveledDistance}";
        }
    }
}
