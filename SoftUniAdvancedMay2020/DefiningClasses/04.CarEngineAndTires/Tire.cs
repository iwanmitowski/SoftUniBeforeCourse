using System;
using System.Collections.Generic;
using System.Text;

namespace _04.CarEngineAndTires
{
    class Tire
    {
        public Tire(double pressure)
        {
          
            this.Pressure = pressure;
        }

        private double pressure;

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

    }
}
