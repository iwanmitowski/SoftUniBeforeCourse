using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _02.VehicleExtension
{
    public class FuelOutOfTankException : Exception
    {
        public FuelOutOfTankException()
        {
        }

        public FuelOutOfTankException(string message) : base(message)
        {
        }
    }
}
