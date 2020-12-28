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
            double dahlia = 3.80;
            double tulip = 2.80;
            int narcissus = 3;
            double gladiolus = 2.50;

            double price = 0.00;
            switch (flowerType)
            {
                case "Roses":
                    price = flowerNum * rose;
                    if (flowerNum > 80)
                    {
                        price -= price * 0.10;
                    }
                    if (price <= budget)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowerNum} {flowerType} and {budget - price:f2} leva left.");
                    }
                    else if (price > budget)
                    {
                        Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                    }
                    break;
                case "Dahlias":
                    price = flowerNum * dahlia;
                    if (flowerNum > 90)
                    {
                        price -= price * 0.15;
                    }
                    if (price <= budget)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowerNum} {flowerType} and {budget - price:f2} leva left.");
                    }
                    else if (price > budget)
                    {
                        Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                    }
                    break;
                case "Tulips":
                    price = flowerNum * tulip;
                    if (flowerNum > 80)
                    {
                        price -= price * 0.15;
                    }
                    if (price <= budget)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowerNum} {flowerType} and {budget - price:f2} leva left.");
                    }
                    else if (price > budget)
                    {
                        Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                    }
                    break;
                case "Narcissus":
                    price = flowerNum * narcissus;
                    if (flowerNum < 120)
                    {
                        price += price * 0.15;
                    }
                    if (price <= budget)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowerNum} {flowerType} and {budget - price:f2} leva left.");
                    }
                    else if (price > budget)
                    {
                        Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                    }
                    break;
                    case "Gladiolus":
                    price = flowerNum * gladiolus;
                    if (flowerNum < 80)
                    {
                        price += price * 0.20;
                    }
                    if (price <= budget)
                    {
                        Console.WriteLine($"Hey, you have a great garden with {flowerNum} {flowerType} and {budget - price:f2} leva left.");
                    }
                    else if (price > budget)
                    {
                        Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
                    }
                    break;


                default:
                    break;
            }
        }
    }
}
