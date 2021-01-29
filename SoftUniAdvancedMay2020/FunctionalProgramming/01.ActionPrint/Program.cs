using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> Print = str =>
            {
                foreach (var name in str)
                {
                    Console.WriteLine(name);
                }
            };

            string[] names = Console.ReadLine().Split();
            Print(names);
        }
    }
}
