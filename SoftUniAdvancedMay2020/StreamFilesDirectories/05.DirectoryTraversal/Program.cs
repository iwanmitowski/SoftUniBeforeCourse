using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchExtension = ".";
            string path = "./";

            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();

            string[] fileNames = Directory.GetFiles(path, $"*{searchExtension}*");

            StringBuilder sb = new StringBuilder();

            foreach (var filePath in fileNames)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                string extension = fileInfo.Extension;
                string name = fileInfo.Name;
                double length = fileInfo.Length / 1024.0;

                if (dictionary.ContainsKey(extension)==false)
                {
                    dictionary.Add(extension, new Dictionary<string, double>());
                }
                dictionary[extension].Add(name, length);
            }

            foreach ((string currExtension, Dictionary<string,double> fileInformation) in dictionary.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                sb.AppendLine(currExtension);
                foreach ((string name , double size) in fileInformation.OrderBy(x=>x.Value))
                {
                    sb.AppendLine($"--{name} - {size:f3}kb");
                }
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dest = Path.Combine(desktopPath, "report.txt");
            File.WriteAllText(dest, sb.ToString());
        }
    }
}
