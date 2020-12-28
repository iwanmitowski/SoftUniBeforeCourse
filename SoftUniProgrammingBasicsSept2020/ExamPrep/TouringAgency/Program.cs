using System;

namespace TouringAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string packageType = Console.ReadLine();
            string vip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            

            if (days>7)
            {
                days--;
            }
            if (days<1)
            {
                Console.WriteLine("Days must be positive number!");
                Environment.Exit(0);
            }


            double priceForDay = 0;
            
            if (town=="Bansko"||town=="Borovets")
            {
               
                if (packageType=="withEquipment")
                {
                    priceForDay = 100;
                    if (vip == "yes")
                    {
                        priceForDay -= priceForDay * 0.1;
                    }
                    
                }
                else if (packageType == "noEquipment")
                {
                    priceForDay = 80;
                    if (vip == "yes")
                    {
                        priceForDay -= priceForDay * 0.05;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    Environment.Exit(0);
                }
                double finalPrice = priceForDay * days;
                Console.WriteLine($"The price is {finalPrice:f2}lv! Have a nice time!");
            }
            else if (town=="Varna"|| town=="Burgas")
            {
                
                if (packageType == "withBreakfast")
                {
                    priceForDay = 130;
                    if (vip == "yes")
                    {
                        priceForDay -= priceForDay * 0.12;
                    }
                }
                else if (packageType == "noBreakfast")
                {
                    priceForDay = 100;
                    if (vip == "yes")
                    {
                        priceForDay -= priceForDay * 0.7;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    Environment.Exit(0);
                }
                double finalPrice = priceForDay * days;
                Console.WriteLine($"The price is {finalPrice:f2}lv! Have a nice time!");
            }
            else
            {
                Console.WriteLine("Invalid input!");
                Environment.Exit(0);
            }

        }
    }
}
