using System;
using System.Collections.Generic;
using System.Text;

namespace _01.CompanyRoaster
{
    class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}
