using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    class OutsideTable : Table
    {
        private const decimal TablePricePerPerson = 3.50M;

        public OutsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, TablePricePerPerson)
        {
        }
    }
}
