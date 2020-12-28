using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double wr = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());

            double distance = meters * timeForMeter;
            double delay = Math.Floor(meters / 15) * 12.5;
            double totalTime = distance + delay;
            if (wr<=totalTime)
            {
                Console.WriteLine($"No, he failed! He was {totalTime-wr:F2} seconds slower.");

            }
            else if (wr>totalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
        }
    }
}
