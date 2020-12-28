using System;

namespace GodzilaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double clothPerStat = double.Parse(Console.ReadLine());

            double decore = budget * 0.1;
            double sumCloth = statists * clothPerStat;
           
            if (statists>150)
            {
                sumCloth = sumCloth - sumCloth * 0.1;

            }
            double totalSum = decore + sumCloth;

            if (totalSum>budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalSum - budget:F2} leva more.");
            }
            else if (totalSum<=budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget-totalSum:F2} leva left.");
            }
        }
    }
}
