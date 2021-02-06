using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> peopleSorted = new SortedSet<Person>();
            HashSet<Person> peopleHash = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], int.Parse(input[1]));
                peopleSorted.Add(person);
                peopleHash.Add(person);
               
            }

            Console.WriteLine(peopleSorted.Count);
            Console.WriteLine(peopleHash.Count);

        }
    }
}
