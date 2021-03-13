using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    class InsideTable : Table
    {
        private const decimal TablePricePerPerson = 2.50M;
        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, TablePricePerPerson)
        {
        }
    }
}
