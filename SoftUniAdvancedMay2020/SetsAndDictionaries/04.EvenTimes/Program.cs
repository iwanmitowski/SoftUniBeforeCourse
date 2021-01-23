using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> numbers = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string num = Console.ReadLine();

                if (numbers.ContainsKey(num)==false)
                {
                    numbers.Add(num, 0);
                }
                numbers[num]++;


            }

           KeyValuePair<string,int> kvp = numbers.First(x => x.Value % 2 == 0);

            Console.WriteLine(kvp.Key);
        }
    }
}
