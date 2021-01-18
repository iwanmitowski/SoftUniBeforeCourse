using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> boxes = new Stack<int>(clothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = rackCapacity;
            int countRacks = 1;

            while (boxes.Count > 0)
            {
                int currentCloth = boxes.Peek();

                if (currentRackCapacity >= currentCloth)
                {
                    currentRackCapacity -= currentCloth;
                    boxes.Pop();
                }
                else
                {
                    countRacks++;
                    currentRackCapacity = rackCapacity;
                }


            }
            Console.WriteLine(countRacks);
        }

    }
}
