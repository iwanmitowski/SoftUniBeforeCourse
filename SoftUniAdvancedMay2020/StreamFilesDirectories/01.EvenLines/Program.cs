using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("data", "text.txt");
            string dest = Path.Combine("data", "output.txt");

            using StreamReader streamReader = new StreamReader(path);
            using StreamWriter streamWriter = new StreamWriter(dest);

            string line = streamReader.ReadLine();
            int counter = 0;

            while (line!=null)
            {
                line = line.Replace('-', '@');
                line = line.Replace(',', '@');
                line = line.Replace('.', '@');
                line = line.Replace('!', '@');
                line = line.Replace('?', '@');
                string[] lineArr = line.Split().Reverse().ToArray();

                string result = string.Join(" ", lineArr);
                if (counter%2==0)
                {
                    Console.WriteLine(result);
                }
                counter++;


                line = streamReader.ReadLine();
            }

        }
    }
}
