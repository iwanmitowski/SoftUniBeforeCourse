using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Core.Factories.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core.Factories
{
    class FirePotionFactory : IFirePotionFactory
    {
        public Item CreateFirePotion()
        {
            return new FirePotion();
        }
    }
}
