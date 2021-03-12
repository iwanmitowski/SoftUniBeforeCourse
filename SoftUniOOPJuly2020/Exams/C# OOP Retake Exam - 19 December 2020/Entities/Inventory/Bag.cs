using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    abstract class Bag : IBag
    {
        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            items = new List<Item>();
            Capacity = 100;
        }

        public int Capacity { get; set; }

        public int Load => items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();
        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var itemType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.StartsWith(name) && !x.IsAbstract)
                .FirstOrDefault();

            var itemToRemove = items.FirstOrDefault(x => x.GetType() == itemType);

            if (itemToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(itemToRemove);

            return itemToRemove;

        }
    }
}
