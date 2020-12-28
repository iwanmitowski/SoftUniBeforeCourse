using System;

namespace NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintMatrix(n);


            // reversed pyramid
            //for (int i = 1; i < 5; i++)
            //{
            //    for (int j = 1; j <= 5 - i; j++)
            //    {
            //        Console.Write("$");
            //    }
            //    Console.WriteLine();
            //    for (int k = 1; k <= i; k++)
            //    {
            //        Console.Write(" ");
            //    }
            //}




        }

        static void PrintMatrix(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }



        }
    }
}
