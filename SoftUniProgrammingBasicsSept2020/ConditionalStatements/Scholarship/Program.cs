using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialSchol = Math.Floor(minSalary * 0.35);
            double gradeSchol = Math.Floor(grade * 25);

            if (grade >= 5.50 && money <= minSalary && socialSchol < gradeSchol)
            {
                Console.WriteLine($"You get a scholarship for excellent results {gradeSchol} BGN");
            }
            else if (grade >= 5.50 && money <= minSalary && socialSchol > gradeSchol)
            {
                Console.WriteLine($"You get a Social scholarship {socialSchol} BGN");
            }
            
            else if (money>=minSalary && grade<5.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (money<minSalary && grade>4.50 && grade <5.50)
            {
                Console.WriteLine($"You get a Social scholarship {socialSchol} BGN");
            }
            else if (grade>=5.50 && money>=minSalary)
            {
                Console.WriteLine($"You get a scholarship for excellent results {gradeSchol} BGN");
            }
            else if(money<minSalary && grade <=4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            


        }
    }
}
