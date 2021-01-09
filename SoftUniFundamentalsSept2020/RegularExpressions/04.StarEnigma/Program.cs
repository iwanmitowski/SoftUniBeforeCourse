using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"[^\@\-\!\:\>]*@([A-Z][a-z]+)[^\@\-\!\:\>]*:(\d+)[^\@\-\!\:\>]*!([A|D])[^\@\-\!\:\>]*![^\@\-\!\:\>]*->(\d+)[\w+]*";
            Regex regex = new Regex(pattern);

            List<string> atacked = new List<string>();
            List<string> destroyed = new List<string>();


            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                int starCounter = 0;

                foreach (var c in message.ToLower())
                {
                    if (c == 's' | c == 't' | c == 'a' | c == 'r')
                    {
                        starCounter++;
                    }
                }
                string decrypted = string.Empty;

                foreach (var c in message)
                {
                    int currChar = (int)c - starCounter;
                    decrypted += (char)currChar;
                }

                Match matching = regex.Match(decrypted);

                string planetName = matching.Groups[1].Value;
                //int planetPopulation = int.Parse(matching.Groups[2].Value);
                string atkOrDestr = matching.Groups[3].Value;
                //int soldierCount = int.Parse(matching.Groups[4].Value);

                if (atkOrDestr=="A")
                {
                    atacked.Add(planetName);
                }
                else if (atkOrDestr=="D")
                {
                    destroyed.Add(planetName);
                }

                
            }
            Console.WriteLine($"Attacked planets: {atacked.Count}");
            if (atacked.Count>0)
            {
                foreach (var planet in atacked.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            if (destroyed.Count > 0)
            {
                foreach (var planet in destroyed.OrderBy(x=>x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }
    }
}
