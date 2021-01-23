using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] contestInput = Console.ReadLine().Split(":");

            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> submissions = new SortedDictionary<string, Dictionary<string, int>>();

            while (contestInput[0]!="end of contests")
            {
                string contest = contestInput[0];
                string pass = contestInput[1];

                contests.Add(contest, pass);

                contestInput = Console.ReadLine().Split(":");
            }

            string[] submissionInput = Console.ReadLine().Split("=>",StringSplitOptions.RemoveEmptyEntries);
            while (submissionInput[0]!="end of submissions")
            {
                string contest = submissionInput[0];
                string pass = submissionInput[1];
                string username = submissionInput[2];
                int points = int.Parse(submissionInput[3]);

                if (!contests.ContainsKey(contest) || contests[contest] != pass)
                {
                    submissionInput = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (submissions.ContainsKey(username) == false)
                {
                    submissions.Add(username, new Dictionary<string, int>());
                    submissions[username].Add(contest, points);
                }
                else
                {
                    if (submissions[username].ContainsKey(contest)==false)
                    {
                        submissions[username].Add(contest, points);
                    }
                    else
                    {
                        if (points > submissions[username][contest])
                        {
                            submissions[username][contest] = points;
                        }
                    }
                    
                }

                submissionInput = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            KeyValuePair<string, Dictionary<string, int>> kvp = submissions.OrderByDescending(x => x.Value.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach ((string user, Dictionary<string,int> results)  in submissions)
            {
                Console.WriteLine(user);
                foreach ((string course, int points) in results.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {course} -> {points}");
                }
            }
        }
    }
}
