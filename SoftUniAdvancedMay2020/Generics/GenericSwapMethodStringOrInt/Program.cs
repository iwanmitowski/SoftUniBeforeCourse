using System;
using System.Linq;

namespace GenericSwapMethodStringOrInt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Boxes<int> boxes = new Boxes<int>();

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.AddBox(box);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            boxes.Swap(indexes[0], indexes[1]);

            Console.WriteLine(boxes);
            //int n = int.Parse(Console.ReadLine());
            //Boxes<string> boxes = new Boxes<string>();

            //for (int i = 0; i < n; i++)
            //{
            //    Box<string> box = new Box<string>(Console.ReadLine());
            //    boxes.AddBox(box);
            //}

            //int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //boxes.Swap(indexes[0], indexes[1]);

            //Console.WriteLine(boxes);
        }
    }
}
