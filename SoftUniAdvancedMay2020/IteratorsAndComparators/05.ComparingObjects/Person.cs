using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }
            if (this.Age != other.Age)
            {
                return this.Age.CompareTo(other.Age);
            }
            if (this.Town!=other.Town)
            {
                return this.Town.CompareTo(other.Town);
            }
            return 0;
        }
    }
}
