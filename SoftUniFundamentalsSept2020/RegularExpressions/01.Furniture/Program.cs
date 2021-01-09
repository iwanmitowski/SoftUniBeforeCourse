using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(\w+)<<(\d+\.?\d+)!(\d+)";

            Regex regex = new Regex(pattern);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bought furniture:");

            double totalSum = 0;

            string input = Console.ReadLine();
            while (input!="Purchase")
            {
                Match matches = regex.Match(input);

                if (matches.Success)
                {
                    string product = matches.Groups[1].Value;
                    double price = double.Parse(matches.Groups[2].Value);
                    int quantity = int.Parse(matches.Groups[3].Value);

                    totalSum += price * quantity;
                    sb.AppendLine(product);
                }
                
                input = Console.ReadLine();
            }
            sb.AppendLine($"Total money spend: {totalSum:f2}");

            Console.WriteLine(sb);
        }
    }
}
