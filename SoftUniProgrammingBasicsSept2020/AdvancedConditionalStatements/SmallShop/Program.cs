using System;

namespace SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string town = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());

            

            if (type == "coffee")
            {
                if (town=="Varna")
                {
                    Console.WriteLine(0.45*number);
                }
                else if (town=="Plovdiv")
                {
                    Console.WriteLine(0.40*number);
                }
                else if (town=="Sofia")
                {
                    Console.WriteLine(0.50*number);
                }
            }
            else if (type=="water")
            {
                if (town == "Varna")
                {
                    Console.WriteLine(0.70 * number);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(0.70 * number);
                }
                else if (town == "Sofia")
                {
                    Console.WriteLine(0.80 * number);
                }
            }
            else if (type == "beer")
            {
                if (town == "Varna")
                {
                    Console.WriteLine(1.10 * number);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(1.15 * number);
                }
                else if (town == "Sofia")
                {
                    Console.WriteLine(1.20 * number);
                }
            }
            else if (type == "sweets")
            {
                if (town == "Varna")
                {
                    Console.WriteLine(1.35 * number);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(1.30 * number);
                }
                else if (town == "Sofia")
                {
                    Console.WriteLine(1.45 * number);
                }
            }
            else if (type == "peanuts")
            {
                if (town == "Varna")
                {
                    Console.WriteLine(1.55 * number);
                }
                else if (town == "Plovdiv")
                {
                    Console.WriteLine(1.50 * number);
                }
                else if (town == "Sofia")
                {
                    Console.WriteLine(1.60 * number);
                }
            }



        }
    }
}
