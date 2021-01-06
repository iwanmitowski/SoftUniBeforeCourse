using System;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine().TrimStart('0');
            int number = int.Parse(Console.ReadLine());

            if (bigNum.Length == 0 || number == 0)
            {
                Console.WriteLine("0");
                Environment.Exit(0);
            }

            

            StringBuilder sb = new StringBuilder();
            int toAdd = 0;

            foreach (var digit in bigNum.Reverse())
            {
                int currNum = int.Parse(digit.ToString());

                int calc = currNum * number+ toAdd;

                int lefted = calc % 10;
                toAdd = calc / 10;
                

                sb.Insert(0,lefted);

            }
            if (toAdd > 0)
            {
                sb.Insert(0, toAdd);
            }
           
            Console.WriteLine(sb);
        }
    }
}
