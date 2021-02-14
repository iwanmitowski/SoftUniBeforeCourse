using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinName = 1;
        private const int MaxName = 15;
        private const int MinToppings = 0;
        private const int MaxToppings = 10;
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < MinName || value.Length > MaxName)
                {
                    throw new ArgumentException($"Pizza name should be between {MinName} and {MaxName} symbols.");
                }
                name = value;
            }
        }


        public Dough Dough
        {
            get { return dough; }
            private set { dough = value; }
        }


        public int ToppingsCount => this.toppings.Count;

        public double TotalCalories => CalculateCalories();

        public void AddTopping(Topping topping)
        {
            if (toppings.Count<MinToppings||toppings.Count>=MaxToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
            }
            this.toppings.Add(topping);
        }

        private double CalculateCalories()
        {
            double res = this.Dough.DoughCalories;
            foreach (Topping topping in toppings)
            {
                res += topping.ToppingCalories;
            }
            return res;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
