using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double moneyToCoins = money * 100;

            while (money>0)
            {
                Console.WriteLine(moneyToCoins);
            }
        }
    }
}
