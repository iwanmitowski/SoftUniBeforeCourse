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
            int totalCakePieces = 0;
            int cakes = 0;

            string imput = Console.ReadLine();

            while (true)
            {
                
                if (imput == "STOP")
                {
                    Console.WriteLine($"No more cake left! You need {cakeSize-totalCakePieces} pieces more.");
                    break;
                }
                cakes = int.Parse(imput);

                totalCakePieces += cakes;
                if (totalCakePieces>=cakeSize)
                {
                    Console.WriteLine($"No more cake left! You need {totalCakePieces- cakeSize} pieces more.");
                    break;
                }

                imput = Console.ReadLine();
            }

        }
    }
}
