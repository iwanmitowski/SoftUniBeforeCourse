using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split("!")
                .ToList();

            string input = Console.ReadLine();
                

            while (input!="Go Shopping!")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commands[0];
                string item = commands[1];

                if (command=="Urgent")
                {
                    if (!list.Contains(item))
                    {
                        list.Insert(0, item);
                    }
                }
                else if (command == "Unnecessary")
                {
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
                else if (command == "Correct")
                {
                    string oldItem = commands[1];
                    string newItem = commands[2];

                    if (list.Contains(oldItem))
                    {
                        int indexOfOldItem = list.IndexOf(oldItem);
                        list.RemoveAt(indexOfOldItem);
                        list.Insert(indexOfOldItem, newItem);
                    }

                }
                else if (command == "Rearrange")
                {
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                        list.Add(item);
                    }
                }



                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",list));
        }
    }
}
