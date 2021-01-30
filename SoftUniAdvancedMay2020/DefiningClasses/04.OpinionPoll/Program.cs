using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses

{
    public class StartUp

    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                Person person = new Person(tokens[0], int.Parse(tokens[1]));

                people.Add(person);
            }

            people = people.OrderBy(p => p.Name).Where(p => p.Age > 30).ToList();
            foreach (var p in people)
            {
                Console.WriteLine(p);
            }
        }
    }
}
