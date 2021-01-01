using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();

            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            bool isObtained = false;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    string material = input[i + 1].ToLower();
                    int quantity = int.Parse(input[i]);

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;

                            if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (material == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }

                            isObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(material) == false)
                        {
                            junk.Add(material, 0);
                        }

                        junk[material]+=quantity;
                    }
                }
                if (isObtained)
                {
                    break;
                }
            }

            foreach (var material in keyMaterials.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junk.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }


        }
    }
}
