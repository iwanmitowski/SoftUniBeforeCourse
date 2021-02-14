using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public IReadOnlyList<Product> Products
        {
            get
            {
                return this.bag.AsReadOnly();
            }
        }

        public void AddProduct(Product product)
        {
            decimal currentMoney = this.money;

            if (this.money < product.Cost)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}"); 

            }
            else
            {
                this.money -= product.Cost;
                bag.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }


        }

        public override string ToString()
        {
            if (this.bag.Count == 0)
            {
                return $"{this.name} - Nothing bought";

            }
            return $"{this.Name} - {string.Join(", ", this.bag)}";


        }
    }
}
