using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FractionalKnapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine()
                .Split()
                .ToArray()[1]);

            int itemsCount = int.Parse(Console.ReadLine()
                .Split()
                .ToArray()[1]);

            List<Item> items = new List<Item>();

            for (int i = 0; i < itemsCount; i++)
            {
                double[] itemTokens = Console.ReadLine()
                    .Split(new string[] {" -> "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                double price = itemTokens[0];
                double weight = itemTokens[1];

                items.Add(new Item(price, weight));
            }

            List<Item> taken = new List<Item>();

            foreach (var item in items.OrderByDescending(i => i.Value))
            {
                if (capacity <= 0)
                {
                    break;
                }

                double itemCapacity = item.Weight;

                if (capacity - itemCapacity >= 0)
                {
                    item.Percentage = 100;
                }
                else
                {
                    item.Percentage = (capacity/itemCapacity) * 100;


                }

                capacity -= itemCapacity;

                taken.Add(item);
            }

            foreach (var item in taken)
            {
                Console.WriteLine(item);
            }

            double totalPrice = taken.Select(x => x.Price * x.Percentage/100).Sum();

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }

    class Item
    {
        public Item(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public double Price { get; private set; }
        public double Weight { get; private set; }
        public double Value => this.Price / this.Weight;
        public double Percentage { get; set; }

        public override string ToString()
        {
            return $"Take {this.Percentage:f2}% of item with price {this.Price:f2} and weight {this.Weight:f2}";
        }
    }
}
