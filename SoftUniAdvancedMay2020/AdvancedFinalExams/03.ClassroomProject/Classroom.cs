using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; private set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (Capacity == Count)
            {
                return "No seats in the classroom";
            }
            this.students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student searched = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (searched==null)
            {
                return "Student not found";
            }

            students.Remove(searched);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> filtered = students.Where(x => x.Subject == subject).ToList();
            if (filtered.Count>0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (Student student in filtered)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().Trim();
            }
            return "No students enrolled for the subject";

        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}



