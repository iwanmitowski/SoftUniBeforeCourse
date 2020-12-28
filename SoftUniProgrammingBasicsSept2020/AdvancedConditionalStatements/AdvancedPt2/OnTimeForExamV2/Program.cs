using System;

namespace OnTimeForExamV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int comeingHour = int.Parse(Console.ReadLine());
            int comeingMin = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMin;
            int comeingTime = comeingHour * 60 + comeingMin;
            int difference = examTime - comeingTime;

            if (difference ==0 || difference<=30)
            {
                Console.WriteLine("On Time");
                if (difference !=0)
                {
                    Console.WriteLine($"{difference} minutes before the start");
                }
            }
            if (difference>30)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{difference} minutes before the start");
            }


        }
    }
}
