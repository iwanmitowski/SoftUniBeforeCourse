using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> track = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            int end = track.Count / 2;
            double sumLeft = 0;
            double sumRight = 0;
            //left
            for (int i = 0; i < end; i++)
            {
                if (track[i]==0)
                {
                    sumLeft*=0.8;
                }
                else
                {
                    sumLeft += track[i];
                }
            }

            //right
            for (int j = track.Count-1 ; j > end; j--)
            {
                if (track[j] == 0)
                {
                    sumRight *= 0.8;
                }
                else
                {
                    sumRight += track[j];
                }
            }

            if (sumLeft<sumRight)
            {
                Console.WriteLine($"The winner is left with total time: {sumLeft}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {sumRight}");
            }
        }
    }
}
