using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> points = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "exam finished")
            {
                string userName = input[0];

                if (input.Length == 3)
                {
                    string language = input[1];
                    int currentPoints = int.Parse(input[2]);

                    if (points.ContainsKey(userName) == false)
                    {
                        points.Add(userName, currentPoints);
                    }
                    else
                    {
                        if (currentPoints> points[userName])
                        {
                            points[userName] = currentPoints;
                        }
                        
                    }

                    if (submissions.ContainsKey(language) == false)
                    {
                        submissions.Add(language, 0);
                    }
                    submissions[language]++;

                }
                else
                {
                    points.Remove(userName);

                }

                input = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Results:");

            foreach (var student in points.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
