using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    class Citizen : IIdentible,IBirthable
    {
        public Citizen(string name, int age, string id,string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthDate;
        }
        public string Birthdate { get; private set; }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

    }
}
