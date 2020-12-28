using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.OldestFamilyMember
{
    class Family
    {
        public List<Person> People { get; set; }

       public void AddMember(List<Person> people, Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember(List<Person> people)
        {
            Person oldestPerson = people.OrderByDescending(x => x.Age).First();
            return oldestPerson;
        }

        

    }
}
