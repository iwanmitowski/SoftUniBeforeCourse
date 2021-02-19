using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehicleExtension
{
    class NegativeFuelException:Exception
    {
        private const string message = "Fuel must be a positive number";

        public NegativeFuelException():base(message)
        {
        }
    }
}
