using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Factories.Contracts
{
    interface ICarFactory
    {
        ICar CreateCar(string type, string model, int horsePower);
    }
}
