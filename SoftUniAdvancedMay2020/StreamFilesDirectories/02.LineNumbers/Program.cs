using System;
using System.IO;
namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "Input.txt");
            string dest = Path.Combine("data", "Output.txt");
            var lines = File.ReadAllLines(path);
            string[] output = new string[lines.Length];

            int counter = 1;
            foreach (var line  in lines)
            {
                output[counter - 1] = $"{counter++}. {line}";
               
            }

            File.WriteAllLines(dest, output);
        }
    }
}
