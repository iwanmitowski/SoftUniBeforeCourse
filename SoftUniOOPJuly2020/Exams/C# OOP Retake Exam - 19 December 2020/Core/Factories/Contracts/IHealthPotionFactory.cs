using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Core.Factories.Contracts
{
    public interface IHealthPotionFactory
    {
        Item CreateHealthPotion();
    }
}
