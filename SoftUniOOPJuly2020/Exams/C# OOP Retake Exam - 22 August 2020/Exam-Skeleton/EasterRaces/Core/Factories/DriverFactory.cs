using EasterRaces.Core.Factories.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Factories
{
    class DriverFactory : IDriverFactory
    {
        public IDriver CreateDriver(string name)
        {
            IDriver driver = new Driver(name);

            return driver;
        }
    }
}
