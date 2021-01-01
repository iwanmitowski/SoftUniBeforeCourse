using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" : ");

            while (input[0]!="end")
            {
                string courseName = input[0];
                string studentName = input[1];

                if (courses.ContainsKey(courseName)==false)
                {
                    courses.Add(courseName, new List<string> { studentName });
                }
                else
                {
                    courses[courseName].Add(studentName);
                }

                input = Console.ReadLine().Split(" : ");
            }

            foreach (var course in courses.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }

        }
    }
}
