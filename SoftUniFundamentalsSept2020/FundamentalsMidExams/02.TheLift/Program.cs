using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int queue = int.Parse(Console.ReadLine());

            List<int> lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();



            for (int i = 0; i < lift.Count; i++)
            {
                //1 
                //4 4 3
                if (lift[i] == 4)
                {
                    continue;
                }
                int freeSpace = 4 - lift[i];
                if (queue < 4 && freeSpace >= queue)
                {

                    lift[i] += queue;
                    queue -= freeSpace;
                    break;
                }

                queue -= freeSpace;
                lift[i] += freeSpace;




            }
            if (lift.Sum() == lift.Count * 4)
            {
                if (queue==0)
                {
                    Console.WriteLine(string.Join(" ", lift));
                    Environment.Exit(0);
                }
                Console.WriteLine($"There isn't enough space! {queue} people in a queue!");
            }
            else
            {
                Console.WriteLine("The lift has empty spots!");
            }

            Console.WriteLine(string.Join(" ", lift));


        }
    }
}
