using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+([[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            string patternNums = @"\d";

            Regex regexValid = new Regex(pattern);
            Regex regexNums = new Regex(patternNums);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                string group = string.Empty;
                Match match = regexValid.Match(barcode);
                if (match.Success)
                {
                    MatchCollection numMatches = regexNums.Matches(barcode);
                    if (numMatches.Count==0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        foreach (Match item in numMatches)
                        {
                            group += item.Value;
                        }
                        Console.WriteLine($"Product group: {group}");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
