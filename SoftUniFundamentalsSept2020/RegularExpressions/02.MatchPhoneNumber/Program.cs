using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:([+359]{4}))([(\s?)|(\-)])(?:[2])\2(?:[0-9]{3})\2(?:[0-9]{4})\b";

            Regex regex = new Regex(pattern);
            string text = Console.ReadLine();
            var matched = regex.Matches(text);

            Console.WriteLine(string.Join(", ",matched));
        }
    }
}
