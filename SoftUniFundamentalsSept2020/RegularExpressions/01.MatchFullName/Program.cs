using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
           string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
           Regex regex = new Regex(pattern);

            string names = Console.ReadLine();

            var matchedNames = regex.Matches(names);

            Console.WriteLine(string.Join(" ",matchedNames));
        }
    }
}
