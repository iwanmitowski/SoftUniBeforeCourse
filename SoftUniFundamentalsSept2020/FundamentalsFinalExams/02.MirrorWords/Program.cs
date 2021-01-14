using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"([@|#])([A-z]{3,})\1\1([A-z]{3,})\1";
            Regex regex = new Regex(pattern);

            List<string> pairs = new List<string>();

            MatchCollection matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match word in matches)
                {
                    string firstWord = word.Groups[2].Value;
                    string secondWord = word.Groups[3].Value;

                    char[] secondWordArr = secondWord.Reverse().ToArray();
                    string secondWordReversed = string.Join("", secondWordArr);

                    if (firstWord == secondWordReversed)
                    {
                        pairs.Add(firstWord);
                        pairs.Add(secondWord);
                    }
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
                Environment.Exit(0);
            }

            List<string> finalResult = new List<string>();

            if (pairs.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                for (int i = 0; i < pairs.Count; i += 2)
                {
                    finalResult.Add($"{pairs[i]} <=> {pairs[i + 1]}");
                }
                Console.WriteLine(string.Join(", ", finalResult));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }


        }
    }
}
