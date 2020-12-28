using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int vcNum = int.Parse(Console.ReadLine());
            int cpuNum = int.Parse(Console.ReadLine());
            int ramNum = int.Parse(Console.ReadLine());

            int vcPrice = 250;
            double cpuPrice = (vcPrice * vcNum) * 0.35;
            double ramPrice = (vcPrice * vcNum) * 0.1;

            double totalSum = (vcPrice * vcNum) + cpuPrice*cpuNum + ramPrice*ramNum;

            if (vcNum>cpuNum)
            {
                totalSum -= totalSum*0.15;
            }

            if (totalSum<=budget)
            {
                Console.WriteLine($"You have {budget-totalSum:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalSum-budget:f2} leva more!");
            }

        }
    }
}
