using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T,V>
    {
        T item1;
        V item2;

        public Tuple(T item1, V item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return  $"{this.item1} -> {this.item2}";
        }
    }
}
