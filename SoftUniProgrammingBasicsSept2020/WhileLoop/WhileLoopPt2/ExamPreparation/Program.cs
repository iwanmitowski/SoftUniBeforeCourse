using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int availablePoorGrades = int.Parse(Console.ReadLine());
            int problemCounter = 0;
            double averageScore = 0;
            int poorGradesCounter = 0;
            int markSum = 0;
            string lastProblem = "";
            while (true)
            {
                string problemName = Console.ReadLine();
                

                if (problemName == "Enough")
                {
                    Console.WriteLine($"Average score: {averageScore:f2}");
                    Console.WriteLine($"Number of problems: {problemCounter}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }
                int mark = int.Parse(Console.ReadLine());
                if (mark <=4)
                {
                    problemCounter++;
                    poorGradesCounter++;
                    markSum += mark;
                }
                else
                {
                    problemCounter++;
                    markSum += mark;
                }
                if (poorGradesCounter==availablePoorGrades)
                {
                    Console.WriteLine($"You need a break, {poorGradesCounter} poor grades.");
                    break;
                }
                averageScore = 1.00 * markSum / problemCounter;
                lastProblem = problemName;
            }

        }
    }
}
