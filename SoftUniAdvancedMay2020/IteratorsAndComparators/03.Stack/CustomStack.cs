using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public int Count => this.items.Count;
        public CustomStack()
        {
            this.items = new List<T>();
        }

        public void Push(T item)
        {
            this.items.Add(item);
        }
        public T Pop()
        {
            if (this.Count==0)
            {
                throw new Exception("No elements");
            }
            T last = this.items.Last();
            items.RemoveAt(this.items.Count - 1);
            return last;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
