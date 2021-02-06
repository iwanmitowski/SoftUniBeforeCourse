using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Person> people = new List<Person>();

            while (input[0]!="END")
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];
                people.Add(new Person(name, age, town));

                input = Console.ReadLine().Split();
            }

            int n = int.Parse(Console.ReadLine()) - 1;

            Person currentPerson = people[n];

            int countOfMatches = 0;

            foreach (Person p in people)
            {
                if (currentPerson.CompareTo(p)==0)
                {
                    countOfMatches++;
                }
            }

            int notMatches = people.Count - countOfMatches;

            if (countOfMatches==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {notMatches} {people.Count}");
            }

        }
    }
}
