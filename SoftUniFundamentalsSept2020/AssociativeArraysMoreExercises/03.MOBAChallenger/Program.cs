using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playersPositionsSkill = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> totalPoints = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] command = input.Split(" -> ");
                    string name = command[0];
                    string position = command[1];
                    int skill = int.Parse(command[2]);

                    if (playersPositionsSkill.ContainsKey(name) == false)
                    {
                        playersPositionsSkill.Add(name, new Dictionary<string, int> { });
                    }

                    if (playersPositionsSkill[name].ContainsKey(position) == false)
                    {
                        playersPositionsSkill[name][position] = 0;
                    }
                    if (playersPositionsSkill[name][position] < skill)
                    {
                        playersPositionsSkill[name][position] = skill;
                    }
                 
                }
                else if (input.Contains("vs"))
                {
                    string[] command = input.Split(" vs ");
                    string p1 = command[0];
                    string p2 = command[1];

                    if (playersPositionsSkill.ContainsKey(p1) && playersPositionsSkill.ContainsKey(p2))
                    {
                        string playerToRemove = string.Empty;

                        foreach (var pos1 in playersPositionsSkill[p1])
                        {
                            foreach (var pos2 in playersPositionsSkill[p2])
                            {
                                if (pos1.Key == pos2.Key)
                                {
                                    if (pos1.Value > pos2.Value)
                                    {
                                        playerToRemove = p2;
                                    }
                                    else if (pos1.Value < pos2.Value)
                                    {
                                        playerToRemove = p1;
                                    }
                                    break;
                                }
                            }
                        }
                        playersPositionsSkill.Remove(playerToRemove);

                    }



                }
                input = Console.ReadLine();
            }

            foreach (var player in playersPositionsSkill.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }

        }
    }
}
