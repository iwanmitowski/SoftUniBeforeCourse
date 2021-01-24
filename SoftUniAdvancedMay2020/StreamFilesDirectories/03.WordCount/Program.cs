using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathWords = Path.Combine("data", "words.txt");
            string pathInput = Path.Combine("data", "input.txt");
            string dest = Path.Combine("data", "output.txt");

            var words = File.ReadAllText(pathWords);
            string[] allWords = words.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var lines = File.ReadAllLines(pathInput);

            Dictionary<string, int> countingWords = new Dictionary<string, int>();

            foreach (var word in allWords)
            {
                countingWords.Add(word, 0);
            }

            foreach (var line in lines)
            {
                string[] currLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < currLine.Length; i++)
                {
                    string currWord = currLine[i].ToLower().Replace('-', ' ').Replace('.', ' ').Replace(',', ' ').Trim();
                    if (countingWords.ContainsKey(currWord))
                    {
                        countingWords[currWord]++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var word in countingWords.OrderByDescending(x=>x.Value))
            {
                sb.AppendLine($"{word.Key} - {word.Value}");
            }

            File.WriteAllText(dest, sb.ToString());
        }
    }
}
