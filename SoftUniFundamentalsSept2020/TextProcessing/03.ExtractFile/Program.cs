using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(@"\");
            string file = input[input.Length - 1];
            string[] fileExtension = file.Split(".");

            Console.WriteLine($"File name: {fileExtension[0]}");
            Console.WriteLine($"File extension: {fileExtension[1]}");

        }
    }
}
