using System;
using System.Linq;

namespace Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceOfJewGold = Console.ReadLine().Split().Select(int.Parse).ToArray();


            int totalExpenses = 0;
            int totalEarnings = 0;
            
            string input = Console.ReadLine();
            while (true)
            {
                if (input=="Jail Time")
                {
                    break;
                }
                string[] LootAndExpenses = input.Split().ToArray();

                int currentExpenses = int.Parse(LootAndExpenses[1]);
                totalExpenses += currentExpenses;

                int goldcounter = 0;
                int jewelcounter = 0;

                foreach (char item in LootAndExpenses[0])
                {
                    if (item=='$')
                    {
                        goldcounter++;
                    }
                    if (item=='%')
                    {
                        jewelcounter++;
                    }
                }

                totalEarnings += goldcounter * priceOfJewGold[1] + jewelcounter * priceOfJewGold[0];
                input = Console.ReadLine();
            }


            int total = totalEarnings-totalExpenses;
            if (totalEarnings >= totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {total}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {Math.Abs(total)}.");
            }
        }
    }
}
