using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStringOrDouble
{
    public class Box<T> where T : IComparable
    {
        T value;
        public T Value { get; private set; }
        public Box(T value)
        {
            this.Value = value;
        }
        public int MyCompare(Box<T> other)
        {
            int result = this.Value.CompareTo(other.Value);
            return result;
        }
        public bool IsLower(Box<T> other)
        {
            int result = this.Value.CompareTo(other.Value);
            return result < 0;
        }

        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }

    }
}
