using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Person member = new Person(tokens[0],int.Parse(tokens[1]));
                family.AddMember(member);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
