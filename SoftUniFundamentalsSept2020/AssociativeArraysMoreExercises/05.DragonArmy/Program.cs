using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, List<int>>> dragons = new Dictionary<string, Dictionary<string, List<int>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string type = input[0];
                string name = input[1];
                string inputDmg = input[2];
                string inputHp = input[3];
                string inputArmor = input[4];

                int dmg = 0;
                int hp = 0;
                int armor = 0;

                if (inputDmg == "null")
                {
                    dmg = 45;
                }
                else
                {
                    dmg = int.Parse(inputDmg);
                }
                if (inputHp == "null")
                {
                    hp = 250;
                }
                else
                {
                    hp = int.Parse(inputHp);
                }
                if (inputArmor == "null")
                {
                    armor = 10;
                }
                else
                {
                    armor = int.Parse(inputArmor);
                }



                if (dragons.ContainsKey(type) == false)
                {
                    dragons.Add(type, new Dictionary<string, List<int>>());
                }

                dragons[type][name] = new List<int>();

                dragons[type][name].Add(dmg);
                dragons[type][name].Add(hp);
                dragons[type][name].Add(armor);

            }
            foreach (var type in dragons)
            {
                double avgDmg = 1.0 * type.Value.Values.Select(x => x[0]).Sum() / dragons[type.Key].Count();
                double avgHp = 1.0 * type.Value.Values.Select(x => x[1]).Sum() / dragons[type.Key].Count();
                double avgArmor = 1.0 * type.Value.Values.Select(x => x[2]).Sum() / dragons[type.Key].Count();

                Console.WriteLine($"{type.Key}::({avgDmg:f2}/{avgHp:f2}/{avgArmor:f2})");

                foreach (var drake in type.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{drake.Key} -> damage: {drake.Value[0]}, health: {drake.Value[1]}, armor: {drake.Value[2]}");
                }

            }


        }
    }
}
