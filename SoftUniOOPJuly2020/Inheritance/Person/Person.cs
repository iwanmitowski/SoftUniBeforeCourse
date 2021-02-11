using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value>=0)
                {
                    this.age = value;

                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }

    }
}
