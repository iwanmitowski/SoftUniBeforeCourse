using System;

namespace _04.TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string replacement = new string('*', bannedWords[i].Length);
                text = text.Replace(bannedWords[i], replacement);
            }
            Console.WriteLine(text);
        }
    }
}
