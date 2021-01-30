using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return people.OrderByDescending(m => m.Age).FirstOrDefault();
        }
    }
}
