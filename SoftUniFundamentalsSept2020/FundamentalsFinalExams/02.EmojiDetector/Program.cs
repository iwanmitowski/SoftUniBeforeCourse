using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternEmoji = @"(\:|\*){2}([A-Z][a-z]{2,})\1{2}";
            string patternNumbers = @"\d";
            BigInteger coolness = 1;
            Regex regexEmojis = new Regex(patternEmoji);
            Regex regexNumbers = new Regex(patternNumbers);

            string text = Console.ReadLine();

            MatchCollection emojiMatches = regexEmojis.Matches(text);
            MatchCollection coolnessThreshold = regexNumbers.Matches(text);

            foreach (Match num in coolnessThreshold)
            {
                coolness *= int.Parse(num.Value);
            }
            Console.WriteLine($"Cool threshold: {coolness}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in emojiMatches)
            {
                BigInteger currentCoolnes = emoji.Value
                    .Substring(2, emoji.Value.Length - 4)
                    .ToCharArray()
                    .Sum(x => (int)x);
                if (currentCoolnes>coolness)
                {
                    Console.WriteLine(emoji.Value);
                }
               
            }

            
        }

    }
}
