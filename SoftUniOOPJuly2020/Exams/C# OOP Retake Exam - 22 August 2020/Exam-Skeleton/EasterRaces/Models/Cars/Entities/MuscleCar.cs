using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    class MuscleCar : Car
    {
        const int CurrentCarCubicCentimeters = 5000;
        const int CurrentMinHorsePower = 400;
        const int CurrentMaxHorsePower = 600;
        public MuscleCar(string model, int horsePower) : base(model, horsePower, CurrentCarCubicCentimeters, CurrentMinHorsePower, CurrentMaxHorsePower)
        {
        }
    }
}
