using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T, U, V>
    {
        T item1;
        U item2;
        V item3;
        public Threeuple(T item1, U item2, V item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public T Item1 { get; set; }
        public U Item2 { get; set; }
        public V Item3 { get; set; }
        public override string ToString()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}";
        }
    }
}
