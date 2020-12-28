using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        /*1 1 2 1 1 1 2 1 1 1
        2 1 */
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bombsettings = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bomb = bombsettings[0];
            int power = bombsettings[1];

            while (numbers.Contains(bomb))
            {
                int bombIndex = numbers.IndexOf(bomb);
                int startExplosion = bombIndex - power;
                int endExplosion = bombIndex + power;

                if (endExplosion>numbers.Count)
                {
                    endExplosion = bombIndex + (numbers.Count - bombIndex);
                }
                if (startExplosion<0)
                {
                    startExplosion = 0;
                }

                int explosionRange = endExplosion - startExplosion + 1;

                numbers.RemoveRange(startExplosion, explosionRange);
                


            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
