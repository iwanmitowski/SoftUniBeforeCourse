using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int wins = 0;
            int battles = 0;
            bool isWon = true;

            while (input != "End of battle")
            {
                battles++;
                int distance = int.Parse(input);

                if(energy<distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    isWon = false;
                    break;
                }

                energy -= distance;
                wins++;


                if (battles % 3 == 0)
                {
                    energy += battles;
                }

                input = Console.ReadLine();
            }

            if (isWon)
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
