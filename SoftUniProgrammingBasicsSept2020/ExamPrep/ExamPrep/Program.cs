using System;

namespace ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Repainting
            double nylon = 1.50;
            double paint = 14.50;
            double thinner = 5;

            int nylonNeeded = int.Parse(Console.ReadLine());
            int paintNeeded = int.Parse(Console.ReadLine());
            int thinnerNeeded = int.Parse(Console.ReadLine());
            int workingHours = int.Parse(Console.ReadLine());

            double totalNylon = nylon * (nylonNeeded + 2);
            double totalPaint = paint * (paintNeeded * 1.10);
            double totalThinner = thinner * thinnerNeeded;
            double bags = 0.40;

            double sum = totalNylon + totalPaint + totalThinner + bags;

            double sumForAllDays = (sum * 0.3) * workingHours;

            Console.WriteLine($"Total expenses: {sumForAllDays+sum:f2} lv.");




        }
        
    }
}
