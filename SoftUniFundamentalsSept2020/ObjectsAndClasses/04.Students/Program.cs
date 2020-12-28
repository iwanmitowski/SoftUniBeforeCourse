using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Student student = new Student(firstName,lastName,grade);
                students.Add(student);
            }

            students = students.OrderByDescending(x=>x.Grade).ToList();

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
