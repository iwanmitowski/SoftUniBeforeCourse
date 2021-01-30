using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
   public class Tire
    {
        public Tire(int tireAge, double tirePressure)
        {
            TireAge = tireAge;
            TirePressure = tirePressure;
        }

        public int TireAge { get; set; }
        public double TirePressure { get; set; }
    }
}
