using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/)([A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);

            string text = Console.ReadLine();

            MatchCollection matches = regex.Matches(text);

            int count = 0;


            List<string> countries = new List<string>();
           
            foreach (Match destination in matches)
            {
                string currentCountry = destination.Groups[2].Value;
                int currLetters = currentCountry.Length;
                count += currLetters;
                countries.Add(currentCountry);
            }

            Console.Write($"Destinations: {string.Join(", ", countries)}");
            Console.WriteLine();
            Console.WriteLine($"Travel Points: {count}");
        }
    }
}
