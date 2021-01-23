using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {                                                   
                string[] input = Console.ReadLine().Split(new[] { " -> ", ","}, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string currentCloth = input[j];

                    if (wardrobe[color].ContainsKey(currentCloth) == false)
                    {
                        wardrobe[color].Add(currentCloth, 1);
                    }
                    else
                    {
                        wardrobe[color][currentCloth]++;
                    }
                }
            }
            string[] lookingInput = Console.ReadLine().Split();
            string lookingColor = lookingInput[0];
            string lookingCloth = lookingInput[1];

            foreach ((string currColor, Dictionary<string, int> clothes) in wardrobe)
            {
                Console.WriteLine($"{currColor} clothes:");
                foreach ((string cloth, int count) in clothes)
                {
                    if (cloth == lookingCloth && currColor == lookingColor)
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {count}");
                    }
                }
            }
        }
    }
}
