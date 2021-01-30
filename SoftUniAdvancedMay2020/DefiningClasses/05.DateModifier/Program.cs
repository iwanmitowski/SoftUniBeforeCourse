using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            double days = DateModifier.GetDaysBetween(firstDate, secondDate);
            Console.WriteLine(days) ;
        }
    }
}
