using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SnowWhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorNamePhy = new Dictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine().Split(" <:> ");

            while (input[0] != "Once upon a time")
            {
                string name = input[0];
                string hatColor = input[1];
                int physics = int.Parse(input[2]);

                if (colorNamePhy.ContainsKey(hatColor) == false)
                {
                    colorNamePhy.Add(hatColor, new Dictionary<string, int>());
                }

                if (colorNamePhy[hatColor].ContainsKey(name) == false)
                {
                    colorNamePhy[hatColor][name] = physics;
                }
                else if (colorNamePhy[hatColor].ContainsKey(name))
                {
                    if (colorNamePhy[hatColor][name]<physics)
                    {
                        colorNamePhy[hatColor][name] = physics;
                    }
                }


                input = Console.ReadLine().Split(" <:> ");
            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();

            foreach (var hatColor in colorNamePhy.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }

            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }




        }
    }
}
