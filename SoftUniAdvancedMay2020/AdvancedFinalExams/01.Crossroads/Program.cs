using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int passedCars = 0;
            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            while (input != "END")
            {
                if (input!="green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;   
                }

                int currentGreen = greenLight;

                string currentCar = string.Empty;

                while (currentGreen>0 && cars.Any())
                {
                    currentCar = cars.Dequeue();
                    currentGreen -= currentCar.Length;
                    passedCars++;
                }

                int freeWindowLeft = freeWindow + currentGreen;

                if (freeWindowLeft<0)
                {
                    int leftChars = Math.Abs(freeWindowLeft);
                    int indexOfHit = currentCar.Length - leftChars;
                    char hit = currentCar[indexOfHit];
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{currentCar} was hit at {hit}.");
                    Environment.Exit(0);
                }
                input = Console.ReadLine();

            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");

        }
    }
}
