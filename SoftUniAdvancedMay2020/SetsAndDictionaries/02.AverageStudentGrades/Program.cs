using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> gradesBook = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (gradesBook.ContainsKey(name)==false)
                {
                    gradesBook.Add(name, new List<decimal> {grade});
                }
                else
                {
                    gradesBook[name].Add(grade);
                }

            }

            foreach (var stud in gradesBook)
            {
                Console.WriteLine($"{stud.Key} -> {string.Join(" ",stud.Value.Select(x=>x.ToString("f2")))} (avg: {stud.Value.Average():f2})");
            }
        }
    }
}
