using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Team> teams = new Dictionary<string, Team>();


            while (input != "END")
            {
                string[] arguments = input.Split(";");
                string teamName = arguments[1];
                switch (arguments[0])
                {
                    case "Team":

                        teams.Add(teamName, new Team(teamName));

                        break;

                    case "Add":

                        try
                        {
                            if (isMissingTeam(teams, teamName) == false)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Player player = new Player(arguments[2], int.Parse(arguments[3]), int.Parse(arguments[4]),
                               int.Parse(arguments[5]), int.Parse(arguments[6]), int.Parse(arguments[7]));

                                teams[teamName].AddPlayer(player);
                            }
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }


                        break;

                    case "Remove":
                        try
                        {
                            if (isMissingTeam(teams, teamName) == false)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                teams[teamName].RemovePlayer(arguments[2]);
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message); ;
                        }


                        break;

                    case "Rating":

                        try
                        {
                            if (isMissingTeam(teams, teamName) == false)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                Console.WriteLine($"{teamName} - {teams[teamName].Rating}");

                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }


                        break;

                    default:
                        break;
                }
                input = Console.ReadLine();

            }
            try
            {


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public static bool isMissingTeam(Dictionary<string, Team> teams, string team)
        {
            return teams.ContainsKey(team);
        }

    }
}
