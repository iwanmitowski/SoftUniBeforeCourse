using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> PrintSir = str =>
            {
                foreach (var name in str)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            string[] names = Console.ReadLine().Split();
            PrintSir(names);
        }
    }
}
