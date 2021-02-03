using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;

        public Box()
        {
            this.items = new List<T>();
        }
        int Count
        {
            get
            {
                return items.Count;
            }
        }

        public void Add(T element)
        {
            this.items.Add(element);
        }

        public T Remove()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("cant remove from empty");
            }

            T lastItem = this.items.Last();
            items.Remove(lastItem);

            return lastItem;
        }
    }
}
