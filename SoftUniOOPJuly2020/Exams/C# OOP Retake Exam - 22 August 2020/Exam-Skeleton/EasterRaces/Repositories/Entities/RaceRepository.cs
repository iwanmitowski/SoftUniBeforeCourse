using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            IRace race = this.GetAll().FirstOrDefault(x => x.Name == name);
            return race;
        }
    }
}
