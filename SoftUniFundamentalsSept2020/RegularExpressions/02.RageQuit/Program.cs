using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            //char[] unique = input.Where(x => !char.IsDigit(x)).Distinct().ToArray();
           
            StringBuilder sb = new StringBuilder();

            string patternText = @"\D+";
            string patternNums = @"\d+";

            Regex regex = new Regex(patternText);
            Regex regexNums = new Regex(patternNums);

            MatchCollection matchesText = regex.Matches(input);
            MatchCollection matchesNums = regexNums.Matches(input);


            for (int i = 0; i < matchesText.Count; i++)
            {
                for (int j = 0; j < int.Parse(matchesNums[i].ToString()); j++)
                {
                    sb.Append(matchesText[i]);
                }
            }
            string output = string.Join("", matchesText);
            int countUnique = output.Where(x => !char.IsDigit(x)).Distinct().Count();
            Console.WriteLine($"Unique symbols used: {countUnique}");
            Console.WriteLine(sb);

        }
    }
}
