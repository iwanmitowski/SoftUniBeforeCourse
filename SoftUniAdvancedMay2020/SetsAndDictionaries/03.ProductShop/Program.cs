using System;
using System.Collections.Generic;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, decimal>> shops = new SortedDictionary<string, Dictionary<string, decimal>>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Revision")
            {
                string shopName = input[0];
                string product = input[1];
                decimal price = decimal.Parse(input[2]);

                if (shops.ContainsKey(shopName)==false)
                {
                    shops.Add(shopName, new Dictionary<string, decimal>());
                }

                shops[shopName].Add(product, price);

                input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
