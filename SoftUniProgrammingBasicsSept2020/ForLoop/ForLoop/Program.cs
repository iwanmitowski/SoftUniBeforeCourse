using System;

namespace ForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            //01. Num 1-100
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }

            //02. NumFromNTo1

            int n = int.Parse(Console.ReadLine());

            for (int i = n; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
