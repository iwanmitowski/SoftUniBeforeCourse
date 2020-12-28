using System;
using System.Collections.Generic;
using System.Text;

namespace _05.ShoppingSpree
{
    class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Bag = new List<string>();
        }

        public string Name { get; set; }
        public int Money { get; set; }

        public List<string> Bag { get; set; }

        
    public override string ToString()
        {
            if (Bag.Count==0)
            {
                return $"{Name} - Nothing bought";
            }
            return $"{Name} - {string.Join(", ",Bag)}";
        }
    }
}
