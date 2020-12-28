using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cakeSize = width * length; 
            int totalCakePieces = width * length;

            while (true)
            {
                string imput = Console.ReadLine();
                if (imput == "STOP ")
                {
                    if (totalCakePieces>0)
                    {
                        Console.WriteLine($" {cakeSize-totalCakePieces} pieces are left.");
                    }
                    
                }
                if (totalCakePieces<=0)
                {
                    Console.WriteLine($"No more cake left! You need {cakeSize-totalCakePieces} pieces more.");
                }
                int cakes = int.Parse(imput);
                totalCakePieces -= cakes;
            }

        }
    }
}
