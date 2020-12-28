using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0]!="end")
            {
                if (command[0]=="Delete")
                {
                    nums.RemoveAll(x => x == int.Parse(command[1]));
                }
                else if (command[0]=="Insert")
                {
                    int index = int.Parse(command[2]);
                    int number = int.Parse(command[1]);
                    nums.Insert(index, number);
                }


                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
