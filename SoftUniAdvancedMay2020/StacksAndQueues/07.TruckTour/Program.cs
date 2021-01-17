using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                pumps.Enqueue(input);
            }

            int index = 0;


            for (int i = 0; i < n; i++)
            {
                long petrol = 0;
                bool isLooped = true;
                for (int j = 0; j < n; j++)
                {
                    string currentPump = pumps.Dequeue();
                    long[] currentPumpValues = currentPump.Split().Select(long.Parse).ToArray();
                    long currentPetrol = currentPumpValues[0];
                    long distance = currentPumpValues[1];

                    petrol += currentPetrol;

                    if (petrol >= distance)
                    {
                        petrol -= distance;

                    }
                    else
                    {
                        isLooped = false;

                    }
                    pumps.Enqueue(currentPump);


                }

                if (isLooped)
                {
                    index = i;
                    break;
                }
                pumps.Enqueue(pumps.Dequeue());


            }
            Console.WriteLine(index);
        }
    }
}
