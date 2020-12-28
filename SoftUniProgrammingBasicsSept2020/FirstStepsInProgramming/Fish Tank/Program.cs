using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read length, wide, heigth, percent
            // V, liters, percent, litersFinal

            int length = int.Parse(Console.ReadLine());
            int wide = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());
            double percentNum = double.Parse(Console.ReadLine());

            int v = length * wide * heigth;
            double liters = v * 0.001;
            double percent = percentNum * 0.01;
            double litersFinal = liters *(1 -percent);
           
            Console.WriteLine(litersFinal);

        }
    }
}
