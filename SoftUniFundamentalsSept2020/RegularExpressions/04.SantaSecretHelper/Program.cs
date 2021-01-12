using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.SantaSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@([A-Za-z]+)[^\@\-\!\:\>]+[\w+]*!([G])!";
            Regex regex = new Regex(pattern);

            int key = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
           
            while (input != "end")
            {
                string currText = string.Empty;

                foreach (char c in input)
                {
                    currText += (char)(c - key);
                }
                if (regex.IsMatch(currText))
                {
                    Match match = regex.Match(currText);
                    sb.AppendLine(match.Groups[1].Value);
                }
                
                input = Console.ReadLine();
                
            }
            Console.WriteLine(sb);
        }
    }
}
