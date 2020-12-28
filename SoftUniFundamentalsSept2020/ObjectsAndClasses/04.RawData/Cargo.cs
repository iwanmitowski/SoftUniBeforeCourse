using System;
using System.Collections.Generic;
using System.Text;

namespace _04.RawData
{
    class Cargo
    {
        public Cargo(Car car)
        {
            CargoWeight = car.CargoWeight;
            CargoType = car.CargoType;
        }

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

    }
}
