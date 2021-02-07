using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Employee>(this.Capacity);
        }

        public string Name { get; set; }
        public int Capacity { get; private set; }
        public int Count => this.data.Count();
        public void Add(Employee employee)
        {
            if (this.data.Count < this.Capacity)
            {
                data.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            Employee searched = data.FirstOrDefault(x => x.Name == name);
            if (searched==null)
            {
                return false;
            }
            data.Remove(searched);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            Employee oldest = data.OrderByDescending(x => x.Age).First();
            return oldest;
        }

        
        public Employee GetEmployee(string name)
        {
            Employee searched = data.First(x => x.Name == name);
            return searched;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var emp in data)
            {
                sb.AppendLine(emp.ToString());
            }

            return sb.ToString();
        }
    }
}
