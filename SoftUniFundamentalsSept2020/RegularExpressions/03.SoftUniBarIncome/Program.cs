using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?([\d+\.?\d*]+)\$";

            Regex regex = new Regex(pattern);
            StringBuilder sb = new StringBuilder();

            string input = Console.ReadLine();
            double totalIncome = 0;

            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    double currentSum = price * quantity;
                    totalIncome += currentSum;

                    sb.AppendLine($"{name}: {product} - {currentSum:f2}");
                }

                input = Console.ReadLine();
            }

            sb.AppendLine($"Total income: {totalIncome:f2}");
            Console.WriteLine(sb);
        }
    }
}
