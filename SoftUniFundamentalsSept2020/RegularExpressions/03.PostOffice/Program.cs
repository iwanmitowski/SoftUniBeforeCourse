using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            //70/100 Да я направя с обект, защотот може да повтаря буква но думата да е с различна дължина!
            string[] input = Console.ReadLine().Split("|");
            string firstPart = input[0];
            string secondPart = input[1];
            string[] thridPartArray = input[2].Split(" ");
            string patternFirst = @"(\#|\$|\%|\*)([A-Z]+)\1";
            string patternSecond = @"(\d{2}):(\d{2})";

            Regex regexFirst = new Regex(patternFirst);
            Regex regexSecond = new Regex(patternSecond);

            MatchCollection first = regexFirst.Matches(firstPart);
            MatchCollection second = regexSecond.Matches(secondPart);


            Dictionary<char, int> lettersAndLength = new Dictionary<char, int>();

            //List<char> lettersFirst = new List<char>();

            foreach (Match letter in first)
            {
                string currWord = letter.ToString();
                for (int i = 1; i <= currWord.Length - 2; i++)
                {
                    lettersAndLength.Add(currWord[i], 0);

                }

            }


            for (int i = 0; i < second.Count; i++)
            {
                int firstPair = int.Parse(second[i].Groups[1].Value.ToString());
                int secondPair = int.Parse(second[i].Groups[2].Value.ToString());

                foreach (var letter in lettersAndLength)
                {
                    if ((int)letter.Key == firstPair)
                    {
                        lettersAndLength[letter.Key] = secondPair + 1;
                        break;
                    }
                }

            }

            StringBuilder sb = new StringBuilder();

            foreach (var word in thridPartArray)
            {
                string current = word;

                foreach (var kvp in lettersAndLength)
                {
                    if (word.StartsWith(kvp.Key) && word.Length == kvp.Value)
                    {
                        sb.AppendLine(word);
                    }
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
