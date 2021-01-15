using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            Queue<string> kidsQueue = new Queue<string>(kids);

            int toss = int.Parse(Console.ReadLine());

            while (kidsQueue.Count>1)
            {
                for (int i = 1; i < toss; i++)
                {
                    string currentKid = kidsQueue.Dequeue();
                    kidsQueue.Enqueue(currentKid);
                }
                Console.WriteLine($"Removed {kidsQueue.Dequeue()}");
            }
            Console.WriteLine($"Last is {kidsQueue.Dequeue()}");
        }
    }
}
