using System;
using System.Collections.Generic;

namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> familyMembers = new List<Person>();

            Family family = new Family();
            

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person member = new Person(name,age);
                family.AddMember(familyMembers, member);
                
            }

            Console.WriteLine(family.GetOldestMember(familyMembers));
        }
    }
}
