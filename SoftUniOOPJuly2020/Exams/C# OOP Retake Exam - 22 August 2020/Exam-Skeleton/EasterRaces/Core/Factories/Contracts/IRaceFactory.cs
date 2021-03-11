using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Factories.Contracts
{
    interface IRaceFactory
    {
        IRace CreateRace(string name, int laps);
    }
}
