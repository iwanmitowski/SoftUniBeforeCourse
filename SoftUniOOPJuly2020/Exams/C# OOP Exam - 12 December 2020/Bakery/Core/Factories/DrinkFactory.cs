using Bakery.Core.Factory.Contracts;
using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bakery.Core.Factory
{
    public class DrinkFactory : IDrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int portion, string brand)
        {
            var drinkType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(type) && !x.IsAbstract)
                .FirstOrDefault();

            IDrink drink = null;
            try
            {
                drink = (IDrink)Activator.CreateInstance(drinkType, name, portion, brand);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.InnerException.Message);
            }

            return drink;
        }
    }
}
