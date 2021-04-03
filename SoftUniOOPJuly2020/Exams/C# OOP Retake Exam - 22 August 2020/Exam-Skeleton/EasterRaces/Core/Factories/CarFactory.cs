using EasterRaces.Core.Factories.Contracts;
using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace EasterRaces.Core.Factories
{
    class CarFactory : ICarFactory
    {
        public ICar CreateCar(string type, string model, int horesePower)
        {
            var carType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(type) && !x.IsAbstract)
                .FirstOrDefault();

            if (carType==null)
            {
                throw new ArgumentException("Invalid Car Type");
            }

            ICar car = null;

            try
            {
                car = (ICar)Activator.CreateInstance(carType,model,horesePower);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.InnerException.Message);
            }

            return car;
        }
    }
}
