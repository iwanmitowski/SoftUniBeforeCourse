using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(studentName)==false)
                {
                    students.Add(studentName, new List<double> {grade});
                }
                else
                {
                    students[studentName].Add(grade);
                }
            }

            foreach (var student in students.OrderByDescending(g=>g.Value.Average()).Where(x=>x.Value.Average() >=4.50))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
