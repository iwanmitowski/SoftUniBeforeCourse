using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());

            double toyNumber = 0;
            double moneyFromToys = 0;
            double money = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i%2==0)
                {
                    money = money+(10*(i/2))-1;
                    
                }
                else
                {
                    toyNumber++;
                }
            }

            moneyFromToys = toyNumber * toysPrice;
            money += moneyFromToys;
            
            if (money >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {money - washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice - money:f2}");
            }
        }
    }
}
