using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"data");
            var dest = Path.Combine("data", "output.txt");
            double size = 0;

            foreach (var file in files)
            {
                var info = new FileInfo(file);
                size += info.Length;
            }
            size = size / 1024 / 1024;
            File.WriteAllText(dest, size.ToString());

        }
    }
}
