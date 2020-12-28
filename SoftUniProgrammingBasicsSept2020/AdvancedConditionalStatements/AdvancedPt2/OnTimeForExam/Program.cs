using System;

namespace OnTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int comeingHour = int.Parse(Console.ReadLine());
            int comeingMin = int.Parse(Console.ReadLine());

            int onTimeMin = 0;
            if (examMin==00)
            {
                examMin = 60;
                onTimeMin = examMin - 30;
            }
            
            if (examHour < comeingHour)
            {
                Console.WriteLine("Late");
            }
            else if (examHour == comeingHour && onTimeMin<examMin)
            {
                Console.WriteLine("On time");
            }

        }
    }
}
