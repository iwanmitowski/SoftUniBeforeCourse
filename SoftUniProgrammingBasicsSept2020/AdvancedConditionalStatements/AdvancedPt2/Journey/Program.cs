using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string function = Console.ReadLine();

            double result = 0;
            if ((function =="/" || function=="%") )
            {
                
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    result = n1 / n2;
                    Console.WriteLine($"{n1} {function} {n2} = {result:f2}");
                }
            }


        }
    }
}
