using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();

            string[] people = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in people)
            {
                participants.Add(person, 0);
            }

            string patternName = @"[\W*\d]";
            string patternNum = @"[\D*]";

            Regex regexName = new Regex(patternName);
            Regex regexNums = new Regex(patternNum);
 
            string input = Console.ReadLine();
            while (input!="end of race")
            {
                string name = regexName.Replace(input,"");
                string nums = regexNums.Replace(input, "");

                int score = 0;

                foreach (var c in nums)
                {
                    int currNum = int.Parse(c.ToString());
                    score += currNum;
                }


                if (participants.ContainsKey(name))
                {
                    participants[name] +=score;
                }


                input = Console.ReadLine();
            }

            int count = 1;

            foreach (var participant in participants.OrderByDescending(x=>x.Value))
            {
                string ending = count == 1 ? "st" : count == 2 ? "nd" : "rd";
               
                Console.WriteLine($"{count++}{ending} place: {participant.Key}");
                
                if (count>3)
                {
                    break;
                }
            }
        }
    }
}
