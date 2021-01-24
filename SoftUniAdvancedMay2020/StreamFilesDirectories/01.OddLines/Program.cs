using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "Input.txt");
            string dest = Path.Combine("data", "Output.txt");
            var lines = File.ReadAllLines(path);
            string[] output = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                if (i%2!=0)
                {
                    output[i - 1] = lines[i];
                   
                    File.WriteAllLines(dest, output);
                }
            }

           

        }
    }
}
