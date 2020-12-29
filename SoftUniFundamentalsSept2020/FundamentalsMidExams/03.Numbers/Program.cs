using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double avg = sequence.Average();

            sequence.Sort();
            sequence.Reverse();

            int count = sequence.Count(x => x > avg);
            if (count == 0)
            {
                Console.WriteLine("No");
                Environment.Exit(0);
            }

            sequence = sequence.Where(x => x > avg).ToList();

            List<int> topSeq = new List<int>();

            if (sequence.Count < 4)
            {
                for (int i = 0; i < sequence.Count; i++)
                {
                    topSeq.Add(sequence[i]);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    topSeq.Add(sequence[i]);
                }
            }
            Console.WriteLine(string.Join(" ", topSeq));


        }
    }
}
