using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine()
                .Split();

            while (input[0]!="End")
            {
                
                string command = input[0];
                int index = int.Parse(input[1]);
                int value = int.Parse(input[2]);
                bool isValidIndex = IsValidIndex(index, targets.Count);

                

                if (command=="Shoot")
                {
                    if (!isValidIndex)
                    {
                        input = Console.ReadLine()
                    .Split();
                        continue;
                    }
                    targets[index] -= value;

                    if (targets[index]<=0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                else if (command=="Add")
                {
                    if (!isValidIndex)
                    {
                        Console.WriteLine("Invalid placement!");
                        input = Console.ReadLine()
                .Split();
                        continue;
                    }

                    targets.Insert(index, value);
                }
                else if (command == "Strike")
                {
                    if (!isValidIndex|| index-value<0 || value+index>targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                        input = Console.ReadLine()
                .Split();
                        continue;
                    }

                    targets.RemoveRange(index - value, (value * 2) + 1);
                }



                input = Console.ReadLine()
                .Split();
            }

            Console.WriteLine(string.Join("|",targets));
        }


        static bool IsValidIndex(int index, int count)
        {
            if (index<0||index>=count)
            {
                return false;
            }

            return true;
        }
    }
}
