using System;
using System.Collections.Generic;
using System.Text;

namespace _06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;

        }

        public string Name { get; set; }
        public int Age { get; set; }


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

            return 0;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this.GetHashCode().CompareTo(obj.GetHashCode())==0)
            {
                return true;
            }
            return false;
        }
    }
}
