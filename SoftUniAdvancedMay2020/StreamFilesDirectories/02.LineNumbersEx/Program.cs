using System;
using System.IO;

namespace _02.LineNumbersEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "text.txt");
            string dest = Path.Combine("data", "output.txt");
            string[] lines = File.ReadAllLines(path);

            int counter = 1;

            foreach (string line in lines)
            {
                int letters = 0;
                int punctuation = 0;
                foreach (var c in line)
                {
                    if (char.IsLetter(c))
                    {
                        letters++;
                    }
                    else if (char.IsPunctuation(c))
                    {
                        punctuation++;
                    }
                }
                lines[counter-1] = $"Line {counter++}: {line} ({letters})({punctuation})";
            }

            File.WriteAllLines(dest, lines);
        }
    }
}
