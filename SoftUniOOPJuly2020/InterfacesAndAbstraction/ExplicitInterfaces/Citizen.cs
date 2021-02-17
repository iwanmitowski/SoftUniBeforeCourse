using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; private set; }
        public string Country { get; private set; }
        public int Age { get; private set; }

        public string GetName()
        {
            return this.Name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }


    }
}
