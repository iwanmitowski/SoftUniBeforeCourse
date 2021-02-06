using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int currentIndex;
        private List<T> items;

        int Count => this.items.Count;
        public ListyIterator(List<T> items)
        {
            this.currentIndex = 0;
            this.items = items;
        }

        public bool HasNext()
        {
            if (currentIndex<Count-1)
            {
                return true ;
            }
            return false;
        }

        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (Count==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.items[this.currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
