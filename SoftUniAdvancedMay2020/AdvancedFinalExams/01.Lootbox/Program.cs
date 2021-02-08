using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int firstItem = firstBox.Peek();
            int secondItem = secondBox.Peek();

            int loot = 0;

            while (firstBox.Count!=0||secondBox.Count!=0)
            {
                int mix = firstItem + secondItem;

                if (mix%2==0)
                {
                    loot += mix;
                    firstBox.Dequeue();
                    secondBox.Pop();

                    if (firstBox.Count==0||secondBox.Count==0)
                    {
                        break;
                    }

                    firstItem = firstBox.Peek();
                    secondItem = secondBox.Peek();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());

                    if (firstBox.Count == 0 || secondBox.Count == 0)
                    {
                        break;
                    }

                    firstItem = firstBox.Peek();
                    secondItem = secondBox.Peek();
                }
            }

            if (firstBox.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count==0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (loot>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {loot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {loot}");
            }
        }
    }
}
