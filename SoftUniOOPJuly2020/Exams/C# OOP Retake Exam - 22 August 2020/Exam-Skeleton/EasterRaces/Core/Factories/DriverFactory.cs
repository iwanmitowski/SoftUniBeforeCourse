using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EasterRaces.Core.Factories.Contracts
{
    class DriverFactory : IDriverFactory
    {
        public IDriver CreateDriver(string name)
        => new Driver(name);
    }
}
