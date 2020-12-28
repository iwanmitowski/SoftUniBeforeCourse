using System;

namespace WhileLoopPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int failure = 0;
            double finalGrade = 0;
            int year = 1;

            while (year<=12)
            {
                double grade = double.Parse(Console.ReadLine());
                
                if (grade < 4)
                {
                    failure++;
                    finalGrade += grade;
                    if (failure == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {year} grade ");
                        break;
                    }
                    continue;
                }
                else
                {
                    finalGrade += grade;
                }
               
                if (year==12)
                {
                    Console.WriteLine($"{name} graduated. Average grade: {finalGrade / year:f2}");
                }
                year++;
            }

            
        }
    }
}
