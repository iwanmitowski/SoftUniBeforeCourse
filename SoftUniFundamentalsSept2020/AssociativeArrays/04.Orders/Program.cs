using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> dictionary = new Dictionary<string, List<double>>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "buy")
            {
                string product = input[0];
                double price = double.Parse(input[1]);
                double quantity = double.Parse(input[2]);

                if (dictionary.ContainsKey(product) == false)
                {
                    dictionary.Add(product, new List<double> { price, quantity });
                }
                else
                {
                    dictionary[product][0] = price;
                    dictionary[product][1] += quantity;
                }
                

                input = Console.ReadLine().Split();
            }

            foreach (var item in dictionary)
            {
                double totalSum = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalSum:f2}");
            }

        }
    }
}
