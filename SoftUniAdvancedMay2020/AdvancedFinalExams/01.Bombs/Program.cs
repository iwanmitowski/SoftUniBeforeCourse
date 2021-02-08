using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            SortedDictionary<string, int> craftedBombs = new SortedDictionary<string, int>();
            craftedBombs.Add("Datura Bombs", 0);
            craftedBombs.Add("Cherry Bombs", 0);
            craftedBombs.Add("Smoke Decoy Bombs", 0);

            int currEffect = bombEffects.Peek();
            int currCasing = bombCasings.Peek();

            while (bombCasings.Count != 0 && bombEffects.Count != 0)
            {


                int mix = currCasing + currEffect;
                if (bombCasings.Count == 0 || bombEffects.Count == 0)
                {
                    break;
                }


                switch (mix)
                {
                    case 40:
                        craftedBombs["Datura Bombs"]++;
                        break;
                    case 60:
                        craftedBombs["Cherry Bombs"]++;
                        break;
                    case 120:
                        craftedBombs["Smoke Decoy Bombs"]++;
                        break;
                    default:

                        break;
                }
                if (mix == 40 || mix == 60 || mix == 120)
                {
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                    if (bombCasings.Count == 0 || bombEffects.Count == 0)
                    {
                        break;
                    }
                    currEffect = bombEffects.Peek();
                    currCasing = bombCasings.Peek();
                }
                else
                {

                    currCasing -= 5;

                }
                if (craftedBombs["Datura Bombs"] >= 3 && craftedBombs["Cherry Bombs"] >= 3 && craftedBombs["Smoke Decoy Bombs"] >= 3)
                {
                    break;
                }


            }


            if (craftedBombs["Datura Bombs"] < 3 || craftedBombs["Cherry Bombs"] <3  || craftedBombs["Smoke Decoy Bombs"] <3)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");

            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");

            }

            foreach ((string bombName, int bombCount) in craftedBombs)
            {
                Console.WriteLine($"{bombName}: {bombCount}");
            }
        }
    }
}
