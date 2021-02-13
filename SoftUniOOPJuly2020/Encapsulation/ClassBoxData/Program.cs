using System;

namespace ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double l = double.Parse(Console.ReadLine());
                double w = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                Box box = new Box(l, w, h);
                Console.WriteLine(box);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
