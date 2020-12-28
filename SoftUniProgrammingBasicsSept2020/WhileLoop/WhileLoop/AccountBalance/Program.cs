using System;

namespace AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double increase = 0;
            double total = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="NoMoreMoney")
                {
                    break;
                }

                increase = double.Parse(input);

                if (increase<0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Increase: {increase:f2}");
                    
                }
                total += increase;
                
                
               
            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
