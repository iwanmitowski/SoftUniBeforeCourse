using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    class WordProperties
    {
        public char Letter { get; set; }
        public int WordLength { get; set; }
    }

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

            List<WordProperties> wordProps = new List<WordProperties>();
            

            //List<char> lettersFirst = new List<char>();

            foreach (Match letter in first)
            {
                string currWord = letter.ToString();
                for (int i = 1; i <= currWord.Length - 2; i++)
                {
                    wordProps.Add(new WordProperties { Letter= currWord[i], WordLength=0});
                    

                }

            }


            for (int i = 0; i < second.Count; i++)
            {
                int firstPair = int.Parse(second[i].Groups[1].Value.ToString());
                int secondPair = int.Parse(second[i].Groups[2].Value.ToString());

                foreach (var letter in wordProps)
                {
                    if ((int)letter.Letter == firstPair)
                    {
                        letter.WordLength = secondPair + 1;
                        break;
                    }
                }

            }

            StringBuilder sb = new StringBuilder();

            foreach (var word in thridPartArray)
            {
                string current = word;

                foreach (var letter in wordProps)
                {
                    if (word.StartsWith(letter.Letter) && word.Length == letter.WordLength)
                    {
                        sb.AppendLine(word);
                    }
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
