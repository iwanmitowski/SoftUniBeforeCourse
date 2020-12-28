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
            decimal[] price = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            while (true)
            {
                
                string input = Console.ReadLine();
                if (input == "done")
                {
                    break;
                }
                int indexOfProduct = Array.IndexOf(nameOfProducts, input);

                Console.WriteLine($"{nameOfProducts[indexOfProduct]} costs: {price[indexOfProduct]}; Available quantity: {quantities[indexOfProduct]}");
                


            }

        }
    }
}
