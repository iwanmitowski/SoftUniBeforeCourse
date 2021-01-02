using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            //To be continued...
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, List<string>> submissions = new Dictionary<string, List<string>>();
            Dictionary<string, int> usersPoints = new Dictionary<string, int>();

            string[] contestInput = Console.ReadLine().Split(":");
            int lastPoints = 0;

            while (contestInput[0]!="end of contests")
            {
                string contest = contestInput[0];
                string pass = contestInput[1];

                if (contests.ContainsKey(contest)==false)
                {
                    contests.Add(contest, pass);
                }

                contestInput = Console.ReadLine().Split(":");
            }

            string[] submissionInput = Console.ReadLine().Split("=>");

            while (submissionInput[0]!="end of submissions")
            {
                string contest = submissionInput[0];
                string password = submissionInput[1];
                string userName = submissionInput[2];
                string points = submissionInput[3];

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (usersPoints.ContainsKey(userName) == false)
                    {
                        usersPoints.Add(userName, 0);
                    }
                    usersPoints[userName] += int.Parse(points);
                    lastPoints = int.Parse(points);

                    if (submissions.ContainsKey(contest) ==false)
                    {
                        
                        submissions.Add(contest, new List<string>() { userName, points,});
                    }
                    else
                    {
                        

                        if (int.Parse(points)>int.Parse(submissions[contest][1]))
                        {
                            
                            submissions[contest][1] = points;
                            usersPoints[userName] -= lastPoints;
                        }
                        
                    }

                }

                submissionInput = Console.ReadLine().Split("=>");
            }


            usersPoints = usersPoints.OrderByDescending(p => p.Value).ToDictionary(x=>x.Key, x=>x.Value);

            foreach (var user in usersPoints)
            {
                Console.WriteLine($"Best candidate is {user.Key} with total {user.Value} points.");
                break;
            }
            Console.WriteLine("Ranking:");
            foreach (var contest in submissions.OrderBy(x=>x.Value[0]))
            {
                Console.WriteLine(contest.Value[0]);
                
            }
        }
    }
}
