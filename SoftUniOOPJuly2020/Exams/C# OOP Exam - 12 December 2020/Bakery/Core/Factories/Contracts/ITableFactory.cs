using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core.Factory.Contracts
{
    public interface ITableFactory
    {
        ITable CreateTable(string type, int tableNUmber, int capacity);
    }
}
