using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            ICar car = this.GetAll().FirstOrDefault(x => x.Model == name);
            return car;
        }
    }
}
