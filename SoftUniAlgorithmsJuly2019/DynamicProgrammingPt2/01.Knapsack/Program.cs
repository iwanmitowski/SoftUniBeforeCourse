using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Knapsack
{
    class Item
    {
        public Item(string name, int weight, int value)
        {
            Name = name;
            Weight = weight;
            Value = value;
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            string itemInput = Console.ReadLine();

            List<Item> items = new List<Item>();

            while (itemInput != "end")
            {
                string[] tokens = itemInput.Split();

                Item item = new Item(tokens[0],
                    int.Parse(tokens[1]),
                    int.Parse(tokens[2]));

                items.Add(item);

                itemInput = Console.ReadLine();
            }

            int[,] itemPrice = new int[items.Count + 1, maxCapacity + 1];
            bool[,] takenItems = new bool[items.Count + 1, maxCapacity + 1];

            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var currentItem = items[itemIndex];
                var currentRow = itemIndex + 1;

                for (int capacity = 0; capacity <= maxCapacity; capacity++)
                {
                    if (currentItem.Weight > capacity)
                    {
                        continue;
                    }

                    int excluding = itemPrice[currentRow - 1, capacity];
                    int including = currentItem.Value + itemPrice[currentRow - 1, capacity - currentItem.Weight];

                    if (including > excluding)
                    {
                        itemPrice[currentRow, capacity] = including;
                        takenItems[currentRow, capacity] = true;
                    }
                    else
                    {
                        itemPrice[currentRow, capacity] = excluding;
                    }

                }
            }

            List<Item> taken = new List<Item>();

            int resultCapacity = maxCapacity;

            for (int itemIndex = items.Count- 1; itemIndex >= 0; itemIndex--)
            {
                if (resultCapacity<=0)
                {
                    break;
                }

                if (takenItems[itemIndex + 1, resultCapacity])
                {
                    var currentItem = items[itemIndex];
                    taken.Add(currentItem);
                    resultCapacity -= currentItem.Weight;
                }

            }

            int totalWeight = taken.Sum(i => i.Weight);
            int totalValue = taken.Sum(i => i.Value);

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");

            foreach (var item in taken.OrderBy(i => i.Name))
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
