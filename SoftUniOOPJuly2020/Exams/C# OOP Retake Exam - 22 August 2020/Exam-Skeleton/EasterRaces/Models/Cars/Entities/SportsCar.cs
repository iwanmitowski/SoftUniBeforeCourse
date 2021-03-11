using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    class SportsCar:Car
    {
        private const double CurrentCubicCentimeters = 3000;
        private const int MinHorsePower = 250;
        private const int MaxHorsePower = 450;

        public SportsCar(string model, int horsePower) : base(model, horsePower, CurrentCubicCentimeters, MinHorsePower, MaxHorsePower)
        {
        }
    }
}
