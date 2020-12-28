using System;

namespace TradeCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());

            switch (town)
            {
                case "Sofia":
                    if (sells >= 0 && sells <= 500)
                    {
                        Console.WriteLine($"{sells * 0.05:F2}");
                    }
                    else if (sells > 500 && sells <= 1000)
                    {
                        Console.WriteLine($"{sells * 0.07:F2}");
                    }
                    else if (sells > 1000 && sells <= 10000)
                    {
                        Console.WriteLine($"{sells * 0.08:F2}");
                    }
                    else if (sells > 10000)
                    {
                        Console.WriteLine($"{sells * 0.12:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "Varna":
                    if (sells >= 0 && sells <= 500)
                    {
                        Console.WriteLine($"{sells * 0.045:f2}");
                    }
                    else if (sells > 500 && sells <= 1000)
                    {
                        Console.WriteLine($"{sells * 0.075:f2}");
                    }
                    else if (sells > 1000 && sells <= 10000)
                    {
                        Console.WriteLine($"{sells * 0.1:f2}");
                    }
                    else if (sells > 10000)
                    {
                        Console.WriteLine($"{sells * 0.13:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                        break;
                case "Plovdiv":
                    if (sells >= 0 && sells <= 500)
                    {
                        Console.WriteLine($"{sells * 0.055:F2}");
                    }
                    else if (sells > 500 && sells <= 1000)
                    {
                        Console.WriteLine($"{sells * 0.08:F2}");
                    }
                    else if (sells > 1000 && sells <= 10000)
                    {
                        Console.WriteLine($"{sells * 0.12:F2}");
                    }
                    else if (sells > 10000)
                    {
                        Console.WriteLine($"{sells * 0.145:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                        break;

                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
