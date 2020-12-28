using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int failure = 0;
            double finalGrade = 0;
            int year = 0;

            while (true)
            {
                double grade = double.Parse(Console.ReadLine());
                year++;
                if (grade<4)
                {
                    failure++;
                    finalGrade += grade;
                    if (failure == 2)
                    {
                        break;
                    }
                }
                else
                {
                    finalGrade += grade;
                }
                
            }
            Console.WriteLine(finalGrade/year);

        }
    }
}
