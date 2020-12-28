using System;
using System.Linq;

namespace ArrayStatistics
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int max = arr.Max();
            int min = arr.Min();
            int sum = arr.Sum();
            double avg = arr.Average();


            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {avg}");

        }


    }
}
 