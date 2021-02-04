using System;

namespace GenericCountMethodStringOrDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Boxes<double> boxes = new Boxes<double>();

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.AddBox(box);
            }


            Box<double> boxToCompare = new Box<double>(double.Parse(Console.ReadLine()));
            int count = boxes.Count(boxToCompare);
            Console.WriteLine(count);
            //int n = int.Parse(Console.ReadLine());
            //Boxes<string> boxes = new Boxes<string>();

            //for (int i = 0; i < n; i++)
            //{
            //    Box<string> box = new Box<string>(Console.ReadLine());
            //    boxes.AddBox(box);
            //}


            //Box<string> boxToCompare = new Box<string>(Console.ReadLine());
            //int count = boxes.Count(boxToCompare);
            //Console.WriteLine(count);

        }


    }
}
