using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    class MuscleCar : Car
    {
        private const double CurrentCubicCentimeters = 5000;
        private const int MinHorsePower = 400;
        private const int MaxHorsePower = 600;

        public MuscleCar(string model, int horsePower) : base(model, horsePower, CurrentCubicCentimeters, MinHorsePower, MaxHorsePower)
        {
        }
    }
}
