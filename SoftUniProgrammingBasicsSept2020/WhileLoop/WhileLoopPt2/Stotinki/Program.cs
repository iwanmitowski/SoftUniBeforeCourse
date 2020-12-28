using System;

namespace Stotinki
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double moneyToCoins = money * 100;
            int coinsCounter = 0;

            //200 100 50 20 10 5 2 1;
            while (moneyToCoins>0)
            {
                if (moneyToCoins-200>=0)
                {
                    moneyToCoins -= 200;
                    coinsCounter++;
                }
                else if (moneyToCoins - 100 >= 0)
                {
                    moneyToCoins -= 100;
                    coinsCounter++;
                }
                else if (moneyToCoins - 50 >= 0)
                {
                    moneyToCoins -= 50;
                    coinsCounter++;
                }
                else if (moneyToCoins - 20 >= 0)
                {
                    moneyToCoins -= 20;
                    coinsCounter++;
                }
                else if (moneyToCoins - 10 >= 0)
                {
                    moneyToCoins -= 10;
                    coinsCounter++;
                }
                else if (moneyToCoins - 5 >= 0)
                {
                    moneyToCoins -= 5;
                    coinsCounter++;
                }
                else if (moneyToCoins - 2 >= 0)
                {
                    moneyToCoins -= 2;
                    coinsCounter++;
                }
                else if (moneyToCoins - 1 >= 0)
                {
                    moneyToCoins -= 1;
                    coinsCounter++;
                }
            }
            Console.WriteLine(coinsCounter);
        }
    }
}
