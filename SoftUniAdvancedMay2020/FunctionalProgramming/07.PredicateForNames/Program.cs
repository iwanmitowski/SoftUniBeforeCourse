using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> filter =(string name, int number) => name.Length <= number;

            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().Where(x=> filter(x, n)).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
