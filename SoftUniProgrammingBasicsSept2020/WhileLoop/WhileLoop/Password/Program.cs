using System;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string nick = Console.ReadLine();
            string password = Console.ReadLine();

            string tryPassword = "";

            while (tryPassword!=password)
            {
                tryPassword = Console.ReadLine();
                
            }
           
                Console.WriteLine($"Welcome {nick}!");
            
        }
    }
}
