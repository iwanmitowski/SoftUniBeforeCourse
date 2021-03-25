using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.TowersOfHanoi
{
    class Program
    {
        static Stack<int> source = new Stack<int>();
        static Stack<int> destination = new Stack<int>();
        static Stack<int> spare = new Stack<int>();

        static int steps = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = n; i >= 1; i--)
            {
                source.Push(i);
            }
            PrintRods();
            MoveDisks(source.Count, source, destination, spare);

        }

        private static void MoveDisks(int n, Stack<int> sourceRod, Stack<int> destinationRod, Stack<int> spareRod)
        {
            if (n == 1)
            {
                steps++;

                destinationRod.Push(sourceRod.Pop());
                Console.WriteLine($"Step #{steps}: Moved disk");
                PrintRods();


            }
            else
            {
                MoveDisks(n - 1, sourceRod, spareRod, destinationRod);
                steps++;
                destinationRod.Push(sourceRod.Pop());
                Console.WriteLine($"Step #{steps}: Moved disk");
                PrintRods();
                MoveDisks(n - 1, spareRod, destinationRod, sourceRod);
            }



        }

        private static void PrintRods()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();

        }
    }

}
