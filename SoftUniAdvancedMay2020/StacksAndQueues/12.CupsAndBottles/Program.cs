using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(cupsInput);

            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(bottlesInput);

            int wastedWater = 0;

            while (cups.Count>0 && bottles.Count>0)
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Peek();

                if (currentCup<=currentBottle)
                {
                    currentCup -= currentBottle;
                    wastedWater += Math.Abs(currentCup);
                    cups.Dequeue();
                }
                else
                {
                    
                    while (currentCup>0)
                    {
                        currentCup -= currentBottle;
                        if (currentCup<=0)
                        {
                            wastedWater += Math.Abs(currentCup);
                            cups.Dequeue();
                            break;
                        }
                        currentBottle = bottles.Pop();

                    }
                }

            }
            if (bottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles.Reverse())}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
    }
}
