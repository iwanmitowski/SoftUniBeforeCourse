using System;

namespace NewHome
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerNum = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            int rose = 5;
            //double dahlia = 3.80;
            //double tulip = 2.80;
            //int narcissus = 3;
            //double gladiolus = 2.50;

            double price = 0.00;
            switch (flowerType)
            {
                case "Roses":
                    price = flowerNum * rose;
                    if (flowerNum>80)
                    {
                        price -= price * 0.1;
                    }
                    if (price<budget)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowerNum}вид цветя and {budget-price:f2} leva left");
                    }
                    else if (price>budget)
                    {
                        Console.WriteLine($"Not enough money, you need {price-budget} leva more.");
                    }
                    break;
                    
                default:
                    break;
            }
        }
    }
}
