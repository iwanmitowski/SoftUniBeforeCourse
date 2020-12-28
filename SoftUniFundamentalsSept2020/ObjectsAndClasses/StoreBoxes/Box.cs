using System;
using System.Collections.Generic;
using System.Text;

namespace StoreBoxes
{
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForBox { get; set; }

    }
}
