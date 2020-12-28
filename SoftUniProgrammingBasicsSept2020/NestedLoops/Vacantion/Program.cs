using System;

namespace Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int moneySaved = 0;

            while (true)
            {

                string destination = Console.ReadLine();
                if (destination=="End")
                {
                    break;
                }
                int budget = int.Parse(Console.ReadLine());
                while (moneySaved < budget)
                {
                    int money = int.Parse(Console.ReadLine());
                    moneySaved += money;
                    if (moneySaved >= budget)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        moneySaved = 0;
                        break;
                    }
                }
                
                
            }
        }
    }
}
