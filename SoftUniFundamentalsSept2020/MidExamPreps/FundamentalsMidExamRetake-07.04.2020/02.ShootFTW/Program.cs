using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootFTW
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            int shotTargets = 0;

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index < 0 || index >= targets.Length || targets[index] == -1)
                {
                    input = Console.ReadLine();
                    continue;
                }


                int value = targets[index];
                targets[index] = -1;
                shotTargets++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i]==-1)
                    {
                        continue;
                    }
                    if (targets[i]>value)
                    {
                        targets[i] -= value;
                    }
                    else
                    {
                        targets[i] += value;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ",targets)}");
        }
    }
}
