using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"((?<day>0[1-9]|[1-2][0-9]|3[0-1])([\.|\-|\/])(?<month>[A-Z][a-z]{2})\2(?<year>[\w+]{4}))";
            Regex regex = new Regex(pattern);
            string dates = Console.ReadLine();

            var matched = regex.Matches(dates);

            foreach (Match item in matched)
            {
                Console.WriteLine($"Day: {item.Groups["day"]}, Month: {item.Groups["month"]}, Year: {item.Groups["year"]}");
            }


        }
    }
}
