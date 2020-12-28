using System;

namespace Birthday_party
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read rent
            // cake = rent * 0.2
            // drinks = cake - (cake*0.45);
            // animator = rent / 3;

            double rent = double.Parse(Console.ReadLine());
            double cake = rent * 0.2;
            double drinks = cake - (cake * 0.45); // cake*0.55
            double animator = rent / 3;
            double sum = rent + cake + drinks + animator;
            Console.WriteLine(sum);
        }
    }
}
