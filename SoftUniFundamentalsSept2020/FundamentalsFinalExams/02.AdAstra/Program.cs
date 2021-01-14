using System;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(\#|\|)([A-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1([0-9]+)\1";
            Regex regex = new Regex(pattern);

            int totalCals = 0;
            int days = 0;

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                totalCals += int.Parse(match.Groups[4].Value);
            }
            days = totalCals / 2000;

            Console.WriteLine($"You have food to last you for: { days} days!");
            foreach (Match food in matches)
            {
                Console.WriteLine($"Item: {food.Groups[2].Value}, Best before: {food.Groups[3].Value}, Nutrition: {food.Groups[4].Value}");
            }
        }
    }
}
