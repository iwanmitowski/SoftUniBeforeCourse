using System;
using System.Linq;

namespace InventoryMatcher
{
    class Program
    {
      
        static void Main(string[] args)
        {
            string[] nameOfProducts = Console.ReadLine().Split();
            long[] quantities = Console.ReadLine().Split().Select(long.Parse).ToArray();
            decimal[] price = new decimal[nameOfProducts.Length];
            price = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            long[] quantity = new long[nameOfProducts.Length];
            for (int i = 0; i < quantities.Length; i++)
            {
                quantity[i] = quantities[i];
            }

            while (true)
            {

                string input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }
                string[] buying = input.Split();


                nameOfProducts.Contains(buying[0]);
                int indexOfProduct = Array.IndexOf(nameOfProducts, buying[0]);

               
               
                if (long.Parse(buying[1]) <=quantity[indexOfProduct])
                {
                    decimal currentPrice = price[indexOfProduct] * int.Parse(buying[1]);
                    quantity[indexOfProduct] -= int.Parse(buying[1]);
                    Console.WriteLine($"{nameOfProducts[indexOfProduct]} x {buying[1]} costs {currentPrice:f2}");
                   
                }
                else if(long.Parse(buying[1]) > quantity[indexOfProduct])
                {
                    Console.WriteLine($"We do not have enough {nameOfProducts[indexOfProduct]}");
                    continue;
                }
                
                
                










            }

        }
    }
}
