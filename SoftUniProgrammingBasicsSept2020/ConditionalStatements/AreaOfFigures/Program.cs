using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read figure
            //if for figures and their input
            //result
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * a:F3}");
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine($"{a * b:F3}");
            }
            else if (figure == "circle")
            {
                double pi = Math.PI;
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(pi*(a * a)):F3}");
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(a * b/2):F3}");
            }
        }
    }
}
