using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());

            int customersPerHour = employee1 + employee2 + employee3;
                        
            int customers = int.Parse(Console.ReadLine());
            int hour = 0;
            while (customers>0)
            {
                
                customers -= customersPerHour;
                
                hour++;



            }
            for (int i = 0; i < hour/4; i++)
            {
                hour++;
            }
            Console.WriteLine($"Time needed: {hour}h.");
          


        }
    }
}
