using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core.Factory.Contracts
{
    public interface IDrinkFactory
    {
        IDrink CreateDrink(string type, string name, int portion, string brand);
    }
}
