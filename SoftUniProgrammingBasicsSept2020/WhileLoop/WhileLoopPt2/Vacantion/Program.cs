using System;

namespace Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneyNow = double.Parse(Console.ReadLine());
            double moneyForActivity = moneyNow;
            int days = 0;
            int spendingDays = 0;
            double moneySaved = 0;

            string activity = Console.ReadLine();
            double moneySpendingNow = double.Parse(Console.ReadLine());
            while (true)
            {


                days++;
                if (activity == "spend")
                {

                    spendingDays++;
                    moneyForActivity -= moneySpendingNow;
                    if (moneyForActivity <= 0)
                    {
                        moneyForActivity = 0;
                        
                        
                    }
                    if (spendingDays == 5)
                    {
                        Console.WriteLine($"You can't save the money.");
                        Console.WriteLine(days);
                        break;
                    }
                }

                if (activity == "save")
                {

                    spendingDays = 0;
                    moneyForActivity += moneySpendingNow;
                    if (moneyForActivity >= moneyNeeded)
                    {
                        Console.WriteLine($"You saved the money for {days} days.");
                        break;
                    }
                }

                activity = Console.ReadLine();
                moneySpendingNow = double.Parse(Console.ReadLine());
            }
        }

    }
}

