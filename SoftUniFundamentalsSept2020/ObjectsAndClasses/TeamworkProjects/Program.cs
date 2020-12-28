using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                string creator = input[0];
                string teamName = input[1];

                Team team = new Team(teamName, creator);

                bool isAlreadyTeam = teams.Select(x => x.TeamName).Contains(teamName);
                bool isAlreadyCreator = teams.Select(x => x.CreatorName).Contains(creator);

                if (isAlreadyTeam)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else
                {
                    if (isAlreadyCreator)
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                    }
                    else
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {creator}");
                    }
                }
            }

            string[] secondInput = Console.ReadLine().Split("->");

            while (secondInput[0] != "end of assignment")
            {
                string member = secondInput[0];
                string teamToJoin = secondInput[1];

                bool isExistingTeam = teams.Select(x => x.TeamName).Contains(teamToJoin);

                bool isAlreadyCreator = teams.Select(x => x.CreatorName).Contains(member);
                bool isAlreadyMember = teams.Select(x => x.Members).Any(x => x.Contains(member));


                if (!isExistingTeam)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (isAlreadyCreator || isAlreadyMember)
                {

                    Console.WriteLine($"Member {member} cannot join team {teamToJoin}!");


                }
                else
                {
                    int index = teams.FindIndex(x => x.TeamName == teamToJoin);

                    teams[index].Members.Add(member);
                }
                secondInput = Console.ReadLine().Split("->");

            }

            List<Team> teamsToDisband = teams.OrderBy(x => x.TeamName).Where(x => x.Members.Count == 0).ToList();
            List<Team> finalTeams = teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).Where(x => x.Members.Count > 0).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (Team team in finalTeams)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.CreatorName}");
                foreach (string member in team.Members.OrderBy(x => x))
                {
                    sb.AppendLine($"-- {member}");
                }
            }

            sb.AppendLine("Teams to disband:");

            foreach (Team team in teamsToDisband)
            {
                sb.AppendLine($"{team.TeamName}");

            }

            Console.WriteLine(sb.ToString());
        }
    }
}
