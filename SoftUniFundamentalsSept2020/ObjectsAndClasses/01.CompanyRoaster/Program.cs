using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.CompanyRoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string department = input[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

            decimal highestAvg = 0;
            string highestDep = string.Empty;

            for (int i = 0; i < employees.Count; i++)
            {
                List<Employee> currDepartment = employees.Where(x => x.Department == employees[i].Department).ToList();
                decimal currDepAvg = currDepartment.Select(x => x.Salary).Average();

                if (currDepAvg > highestAvg)
                {
                    highestAvg = currDepAvg;
                    highestDep = currDepartment[0].Department;
                }
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Highest Average Salary: {highestDep}");
            foreach (Employee employee in employees.OrderByDescending(x=>x.Salary).Where(x=>x.Department==highestDep))
            {
                sb.AppendLine($"{employee.Name} {employee.Salary:f2}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
