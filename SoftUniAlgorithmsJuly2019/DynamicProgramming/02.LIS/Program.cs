using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.LIS
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] solutions = new int[sequence.Length];
            int[] prev = new int[sequence.Length];

            int maxSolution = 0;
            int maxSolutionIndex = 0;

            for (int current = 0; current < sequence.Length; current++)
            {
                int solution = 1;
                var prevIndex = -1;
                int currentNumber = sequence[current];

                for (int solIndex = 0; solIndex < current; solIndex++)
                {
                    int previousNumber = sequence[solIndex];
                    int previousSolution = solutions[solIndex];

                    if (currentNumber > previousNumber && solution <= previousSolution)
                    {
                        solution = previousSolution + 1;
                        prevIndex = solIndex;
                    }
                }

                solutions[current] = solution;
                prev[current] = prevIndex;

                if (solution>maxSolution)
                {
                    maxSolution = solution;
                    maxSolutionIndex = current;
                }
            }

            int index = maxSolutionIndex;

            List<int> result = new List<int>();

            while (index!=-1)
            {
                int currNum = sequence[index];
                index = prev[index];
                result.Add(currNum);
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ",result));
        }

    }
}
