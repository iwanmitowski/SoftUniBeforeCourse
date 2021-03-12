using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory
{
    class Satchel : Bag
    {
        private const int SatchelCapacity = 20;

        public Satchel() : base(SatchelCapacity)
        {
        }
    }
}
