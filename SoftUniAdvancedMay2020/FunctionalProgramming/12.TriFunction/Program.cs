using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int> getSum = n=> n.Select(c=>(int)c).Sum();

            Func<List<string>,int,Func<string,int>,string> nameFunc = (names, n, func) =>
            
                names.FirstOrDefault(x => func(x) >= n);
            ;

            string result = nameFunc(names, n, getSum);
            Console.WriteLine(result);

        }
    }
}
