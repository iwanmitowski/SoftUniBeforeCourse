using EasterRaces.Core.Factories.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasterRaces.Core.Factories
{
    class CarFactory : ICarFactory
    {
        public ICar CreateCar(string type, string model, int horsePower)
        {
            var carType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(type) && !x.IsAbstract)
                .FirstOrDefault();

            if (carType == null)
            {
                throw new ArgumentException("Invalid Car Type!");
            }

            ICar car = null;

            try
            {
                car = (ICar)Activator.CreateInstance(carType, model, horsePower);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.InnerException.Message);
            }

            return car;
        }
    }
}
