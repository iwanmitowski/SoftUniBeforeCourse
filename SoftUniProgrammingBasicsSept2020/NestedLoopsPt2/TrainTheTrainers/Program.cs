using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            string project = Console.ReadLine();
            
            int gradeCounter = 0;
            double allProjectGrades = 0;


            while (project!="Finish")
            {
                double projectCurrentGrades = 0;
                for (int i = 0; i < judges; i++)
                {
                    double grades = double.Parse(Console.ReadLine());
                    projectCurrentGrades += grades;
                    allProjectGrades += grades;
                    gradeCounter++;

                }
                Console.WriteLine($"{project} - {projectCurrentGrades / judges:f2}.");
                project = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {allProjectGrades/gradeCounter:f2}.");
        }
    }
}
