using EasterRaces.Core.Factories.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Core.Factories
{
    class RaceFactory : IRaceFactory
    {
        public IRace CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            return race;
        }
    }
}
