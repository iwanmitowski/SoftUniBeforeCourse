using Students;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] input = Console.ReadLine().Split();
            List<Student> students = new List<Student>();


            while (input[0] != "end")
            {
                Student student = new Student();

                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                string homeTown = input[3];

                if (!IsExisting(students, firstName, lastName))
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;
                    students.Add(student);
                }


                input = Console.ReadLine().Split();
            }

            string nameOfCity = Console.ReadLine();

            List<Student> filteredStudents = students.Where(x => x.HomeTown == nameOfCity).ToList();


            foreach (Student student in filteredStudents)
            {

                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");

            }

        }

        static bool IsExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
