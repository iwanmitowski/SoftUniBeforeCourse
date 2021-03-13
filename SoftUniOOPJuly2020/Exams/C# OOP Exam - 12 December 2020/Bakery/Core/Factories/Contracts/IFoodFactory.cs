using Bakery.Models.BakedFoods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core.Factory.Contracts
{
    public interface IFoodFactory
    {
        IBakedFood CreateFood(string type, string name, decimal price);

    }
}
