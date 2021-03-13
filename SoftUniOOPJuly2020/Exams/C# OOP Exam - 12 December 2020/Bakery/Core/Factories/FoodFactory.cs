using Bakery.Core.Factory.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bakery.Core.Factory
{
    class FoodFactory : IFoodFactory
    {
        public IBakedFood CreateFood(string type, string name, decimal price)
        {
            var foodType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(type) && !x.IsAbstract)
                .FirstOrDefault();

            IBakedFood food = null; 

            try
            {
                food = (IBakedFood)Activator.CreateInstance(foodType, name, price);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.InnerException.Message);
            }

            return food;
        }
    }
}
