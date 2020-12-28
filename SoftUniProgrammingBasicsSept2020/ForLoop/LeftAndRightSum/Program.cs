using System;

namespace LeftAndRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumLeft = 0;
            int sumRight = 0;

                //left
            for (int i = 0; i <n ; i++)
            {
                int n1 = int.Parse(Console.ReadLine());
                
                sumLeft += n1;
                
                
            }
            for (int i = 0; i < n; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                sumRight += n2;
               
            }
            if (sumLeft == sumRight)
            {
                Console.WriteLine($"Yes, sum = {sumRight}");

            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sumLeft - sumRight)}");

            }


        }
    }
}
