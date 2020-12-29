using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine()
                .Split(", ")
                .ToList();

            string[] input = Console.ReadLine()
                .Split(new[] { " - ", ":" }, StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Craft!")
            {
                string command = input[0];
                if (command == "Combine Items")
                {
                    string oldItem = input[1];
                    string newItem = input[2];
                    if (journal.Contains(oldItem))
                    {
                        int indexOldItem = journal.FindIndex(x => x == oldItem);
                        journal.Insert(indexOldItem + 1, newItem);
                    }
                    

                }
                string item = input[1];

                if (command == "Collect")
                {

                    if (!journal.Contains(item))
                    {
                        journal.Add(item);
                    }
                }
                else if (command == "Drop")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                    }
                }
                else if (command == "Renew")
                {
                    if (journal.Contains(item))
                    {
                        journal.Remove(item);
                        journal.Add(item);
                    }
                }



                input = Console.ReadLine()
                .Split(new[] { " - ", ":" }, StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(", ", journal));
        }
    }
}
