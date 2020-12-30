using System;
using System.Text;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalSumWithoutTaxes = 0;


            string input = Console.ReadLine();

            while (true)
            {
                if (input == "special" || input == "regular")
                {
                    break;
                }
                double price = double.Parse(input);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");

                    input = Console.ReadLine();
                    continue;
                }

                totalSumWithoutTaxes += price;


                input = Console.ReadLine();
            }

            double taxes = totalSumWithoutTaxes * 0.2;
            double finalPrice = totalSumWithoutTaxes + taxes;

            if (input == "special")
            {
                finalPrice -= finalPrice * 0.1;
            }

            if (finalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
                Environment.Exit(0);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Congratulations you've just bought a new computer!");
            sb.AppendLine($"Price without taxes: {totalSumWithoutTaxes:f2}$");
            sb.AppendLine($"Taxes: {taxes:f2}$");
            sb.AppendLine("-----------");
            sb.AppendLine($"Total price: {finalPrice:f2}$");
            Console.WriteLine(sb.ToString());
        }
    }
}
