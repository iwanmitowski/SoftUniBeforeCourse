using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            IDriver driver = this.GetAll().FirstOrDefault(x => x.Name == name);
            return driver;
        }
    }
}
