using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = Path.Combine("data", "input1.txt");
            string path2 = Path.Combine("data", "input2.txt");
            string dest = Path.Combine("data", "output.txt");

            var firstInput = File.ReadAllLines(path1);
            var secondInput = File.ReadAllLines(path2);

            List<string> output = new List<string>();

            output = FillingTheList(output, firstInput);
            output = FillingTheList(output, secondInput);
            output.Sort();
            File.WriteAllLines(dest, output);


        }

        static List<string> FillingTheList(List<string> output, string[] input)
        {
            foreach (var item in input)
            {
                output.Add(item);
            }
            return output;
        }

    }
}
