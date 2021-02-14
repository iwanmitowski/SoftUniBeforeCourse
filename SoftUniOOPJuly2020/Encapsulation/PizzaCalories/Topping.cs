using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int BaseCalsPerGram = 2;
        private const int MinWeight = 1;
        private const int MaxWeight = 50;
        private readonly Dictionary<string, double> toppingValues = new Dictionary<string, double>()
        {
            {"meat",1.2},
            {"veggies",0.8},
            {"cheese",1.1},
            {"sauce",0.9 }
        };

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (toppingValues.ContainsKey(value.ToLower()) == false)
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                name = value;
            }
        }

        public int Weight
        {
            get { return weight; }
            set
            {
                if (value<MinWeight||value>MaxWeight)
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                weight = value;
            }
        }

        public double ToppingCalories { get => BaseCalsPerGram * toppingValues[this.Name.ToLower()] * this.Weight; }
    }
}
