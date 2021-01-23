using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // app[vloger][following][volgers]
            //            [followers][volgers]
            Dictionary<string, Dictionary<string, HashSet<string>>> app = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "Statistics")
            {
                string vloggerName = input[0];

                if (input[1] == "joined")
                {
                    if (app.ContainsKey(vloggerName) == false)
                    {
                        app.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        app[vloggerName].Add("following", new HashSet<string>());
                        app[vloggerName].Add("followers", new HashSet<string>());
                    }
                    else
                    {
                        input = Console.ReadLine().Split();
                        continue;
                    }
                }
                else if (input[1] == "followed")
                {
                    string secondVlogger = input[2];
                    if (vloggerName == secondVlogger || !app.ContainsKey(vloggerName) || !app.ContainsKey(secondVlogger))
                    {
                        input = Console.ReadLine().Split();
                        continue;
                    }

                    app[vloggerName]["following"].Add(secondVlogger);
                    app[secondVlogger]["followers"].Add(vloggerName);
                }

                input = Console.ReadLine().Split();
            }

            int counter = 1;

            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");

            app = app.OrderByDescending(x => x.Value["followers"].Count()).ThenBy(x => x.Value["following"].Count).ToDictionary(k => k.Key, v => v.Value);

            foreach ((string vloger, Dictionary<string, HashSet<string>> profile) in app)
            {
                if (counter==1)
                {
                    Console.WriteLine($"{counter++}. {vloger} : {profile["followers"].Count} followers, {profile["following"].Count} following");
                    foreach (string follower in profile["followers"].OrderBy(x=>x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                else
                {
                    Console.WriteLine($"{counter++}. {vloger} : {profile["followers"].Count} followers, {profile["following"].Count} following");
                }
                

            }
        }
    }
}
