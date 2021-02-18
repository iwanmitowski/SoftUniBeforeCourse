using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());
            Console.WriteLine(rect.Draw());

            Circle circ = new Circle(-2);
            Console.WriteLine(circ.CalculateArea());
            Console.WriteLine(circ.CalculatePerimeter());
            Console.WriteLine(circ.Draw());
        }
    }
}
