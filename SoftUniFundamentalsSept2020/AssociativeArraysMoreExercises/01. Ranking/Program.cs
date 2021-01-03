using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            //To be continued... 20/100
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userContestPoints = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> usersPoints = new Dictionary<string, int>();

            string[] contestInput = Console.ReadLine().Split(":");

            while (contestInput[0] != "end of contests")
            {
                string contest = contestInput[0];
                string pass = contestInput[1];

                if (contests.ContainsKey(contest) == false)
                {
                    contests.Add(contest, pass);
                }

                contestInput = Console.ReadLine().Split(":");
            }

            string[] submissionInput = Console.ReadLine().Split("=>");

            while (submissionInput[0] != "end of submissions")
            {
                string contest = submissionInput[0];
                string password = submissionInput[1];
                string userName = submissionInput[2];
                int points = int.Parse(submissionInput[3]);


                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (usersPoints.ContainsKey(userName) == false)
                    {
                        usersPoints.Add(userName, 0);
                    }


                    if (userContestPoints.ContainsKey(userName) == false)
                    {
                        userContestPoints.Add(userName, new Dictionary<string, int>());

                    }
                    if (userContestPoints[userName].ContainsKey(contest) == false)
                    {
                        userContestPoints[userName][contest] = 0;
                    }
                    if (userContestPoints[userName][contest] < points)
                    {
                        usersPoints[userName] -= userContestPoints[userName][contest];
                        userContestPoints[userName][contest] = points;
                        usersPoints[userName] += points;
                    }

                }

                submissionInput = Console.ReadLine().Split("=>");
            }

            string bestUser = usersPoints.Keys.Max();
            int bestUserScore = usersPoints.Values.Max();

            //последният judge тест гърмеше тук, въпреки условието
            foreach (var user in usersPoints)
            {
                if (user.Value==bestUserScore)
                {
                    Console.WriteLine($"Best candidate is {user.Key} with total {user.Value} points.");
                }
            }


            Console.WriteLine("Ranking: ");
            foreach (var user in userContestPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
