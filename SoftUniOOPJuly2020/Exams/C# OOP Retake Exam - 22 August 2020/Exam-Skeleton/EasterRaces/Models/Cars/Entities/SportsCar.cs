using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    class SportsCar : Car
    {
        const int CurrentCarCubicCentimeters = 3000;
        const int CurrentMinHorsePower = 250;
        const int CurrentMaxHorsePower = 450;
        public SportsCar(string model, int horsePower) : base(model, horsePower, CurrentCarCubicCentimeters, CurrentMinHorsePower, CurrentMaxHorsePower)
        {
        }
    }
}
