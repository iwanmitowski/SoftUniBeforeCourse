using System;

namespace ToysShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzle = 2.60;
            int doll = 3;
            double bear = 4.10;
            double minion = 8.2;
            int truck = 2;

            double vacantion = double.Parse(Console.ReadLine());
            int numPuzzle = int.Parse(Console.ReadLine());
            int numDoll = int.Parse(Console.ReadLine());
            int numBear = int.Parse(Console.ReadLine());
            int numMinion = int.Parse(Console.ReadLine());
            int numTruck = int.Parse(Console.ReadLine());
            double rent = 0.0;
            double discount = 0.0;
            double finalPrize = 0.0;
            double totalSum = puzzle * numPuzzle + doll * numDoll + bear * numBear + minion * numMinion + truck * numTruck;
            int totalToys = numPuzzle + numDoll + numBear + numMinion + numTruck;
            if (totalToys >= 50)
            {
                discount = totalSum * 0.25;
                totalSum = totalSum - discount;
                rent = totalSum * 0.1;
                finalPrize = totalSum - rent;

            }
            else
            {
                rent = totalSum * 0.1;
                finalPrize = totalSum - rent;
            }
            if (finalPrize >= vacantion)
            {
                Console.WriteLine($"Yes! {finalPrize - vacantion:F2} lv left.");
            }
            else
            { Console.WriteLine($"Not enough money! {vacantion - finalPrize:F2} lv needed."); }


        }
    }
}
