using System;
using System.Collections.Generic;

namespace _02.MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input!="stop")
            {
                
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(input) ==false)
                {
                    resources.Add(input, 0);
                }

                resources[input] += quantity;

                input = Console.ReadLine();
            }

            foreach (var ore in resources)
            {
                Console.WriteLine($"{ore.Key} -> {ore.Value}");
            }

            
        }
    }
}
