using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftuniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine()
                .Split(", ")
                .ToList();

            string[] command = Console.ReadLine()
                .Split(":")
                .ToArray();

            while (command[0] != "course start")
            {
                string action = command[0];
                string lessonTitle = command[1];

                if (action == "Add")
                {
                    if (!(courses.Contains(lessonTitle)))
                    {
                        courses.Add(lessonTitle);
                    }
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(command[2]);
                    if (!(courses.Contains(lessonTitle)))
                    {
                        courses.Insert(index, lessonTitle);
                    }

                }
                else if (action == "Remove")
                {
                    if (courses.Contains(lessonTitle))
                    {

                        List<string> temp = courses.Where(x => x != lessonTitle).ToList();
                        temp = courses.Where(x => x != $"{lessonTitle}-Exercise").ToList();
                        temp.Remove(lessonTitle);
                        courses = temp;

                    }
                }
                else if (action == "Swap")
                {
                    string firstLesson = command[1];
                    string secondLesson = command[2];

                    if (courses.Contains(firstLesson) && (courses.Contains(secondLesson)))
                    {
                        int indexFirst = courses.IndexOf(firstLesson);
                        int indexSecond = courses.IndexOf(secondLesson);

                        courses.Insert(indexFirst + 1, secondLesson);
                        courses.RemoveAt(indexFirst);

                        courses.Insert(indexSecond + 1, firstLesson);
                        courses.RemoveAt(indexSecond);

                        string firstEx = $"{firstLesson}-Exercise";
                        string secondEx = $"{secondLesson}-Exercise";

                        if (courses.Contains(firstEx))
                        {
                            courses = InsertingAndRemovig(courses, indexFirst, indexSecond, firstEx);
                        }
                        if (courses.Contains(secondEx))
                        {
                            courses = InsertingAndRemovig(courses, indexSecond, indexFirst, secondEx);
                        }
                    }
                }
                else if (action == "Exercise")
                {
                    string exToBeInserted = $"{lessonTitle}-Exercise";

                    if (courses.Contains(lessonTitle) && !(courses.Contains(exToBeInserted)))
                    {
                        int indexOfTheLesson = courses.IndexOf(lessonTitle);
                        courses.Insert(indexOfTheLesson + 1, exToBeInserted);

                    }
                    else if (!(courses.Contains(lessonTitle)))
                    {
                        courses.Add(lessonTitle);
                        courses.Add(exToBeInserted);
                    }
                }

                command = Console.ReadLine()
                .Split(":")
                .ToArray();
            }

            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }

        }


        static List<string> InsertingAndRemovig(List<string> courses, int currIndexFirst, int indexSecond, string Ex)
        {
            int indexFirstEx = currIndexFirst + 1;
            courses.RemoveAt(indexFirstEx);
            courses.Insert(indexSecond + 1, Ex);

            return courses;
        }
    }
}
