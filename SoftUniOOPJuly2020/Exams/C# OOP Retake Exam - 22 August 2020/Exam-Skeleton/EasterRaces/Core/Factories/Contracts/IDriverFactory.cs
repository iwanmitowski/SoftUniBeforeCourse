using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Factories.Contracts
{
    interface IDriverFactory
    {
        IDriver CreateDriver(string name);
    }
}
