using System;

namespace CalculatingRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int area = AreaCalculation(width, height);
            Console.WriteLine(area);
        }

        static int AreaCalculation(int width, int height)
        {
            int area = 0;

            area = width * height;



             return area;
        }

    }
}
