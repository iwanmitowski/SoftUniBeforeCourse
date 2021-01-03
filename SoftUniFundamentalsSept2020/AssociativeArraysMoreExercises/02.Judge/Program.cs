using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> contestsUserPoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> individualStandings = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split(" -> ");

            while (input[0] != "no more time")
            {
                string userName = input[0];
                string contest = input[1];
                int points = int.Parse(input[2]);


                if (individualStandings.ContainsKey(userName) == false)
                {
                    individualStandings.Add(userName, 0);
                }
                individualStandings[userName] += points;



                if (contestsUserPoints.ContainsKey(contest) == false)
                {
                    contestsUserPoints.Add(contest, new Dictionary<string, int>());
                }
                if (contestsUserPoints[contest].ContainsKey(userName) == false)
                {
                    contestsUserPoints[contest][userName] = 0;
                }
                if (contestsUserPoints[contest][userName] < points)
                {
                    individualStandings[userName] -= contestsUserPoints[contest][userName];
                    contestsUserPoints[contest][userName] = points;

                }

                input = Console.ReadLine().Split(" -> ");
            }

            foreach (var contest in contestsUserPoints)
            {
                int count = 1;
                Console.WriteLine($"{contest.Key}: {contest.Value.Count()} participants");

                foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{count}. {user.Key} <::> {user.Value}");
                    count++;
                }

            }

            Console.WriteLine("Individual standings:");

            int currentIndividual = 1;
            foreach (var student in individualStandings.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{currentIndividual}. {student.Key} -> {student.Value}");
                currentIndividual++;
            }

        }
    }
}
