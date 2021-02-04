using System;
using System.Collections.Generic;

namespace GenericBoxOfStringsAndInts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
            //int n = int.Parse(Console.ReadLine());
            //List<Box<string>> boxes = new List<Box<string>>();

            //for (int i = 0; i < n; i++)
            //{
            //    Box<string> box = new Box<string>(Console.ReadLine());
            //    boxes.Add(box);
            //}

            //foreach (var box in boxes)
            //{
            //    Console.WriteLine(box);
            //}
        }
    }
}
