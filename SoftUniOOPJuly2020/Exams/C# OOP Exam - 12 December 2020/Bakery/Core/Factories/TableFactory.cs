using Bakery.Core.Factory.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bakery.Core.Factories
{
    class TableFactory : ITableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            var tableType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(type) && !x.IsAbstract)
                .FirstOrDefault();

            ITable table = null;

            try
            {
                table = (ITable)Activator.CreateInstance(tableType, tableNumber, capacity);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.InnerException.Message);
            }


            return table;
        }
    }
}
