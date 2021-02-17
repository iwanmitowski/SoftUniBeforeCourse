using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    class Citizen : IIdentible,IBirthable,IBuyer
    {
        public Citizen(string name, int age, string id,string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthDate;
            Food = 0;
        }
        public string Birthdate { get; private set; }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
