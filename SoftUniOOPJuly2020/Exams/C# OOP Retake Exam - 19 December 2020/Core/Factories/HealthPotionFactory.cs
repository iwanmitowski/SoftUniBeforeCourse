using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Core.Factories.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core.Factories
{
    class HealthPotionFactory : IHealthPotionFactory
    {
        public Item CreateHealthPotion()
        {
            return new HealthPotion();
        }
    }
}
