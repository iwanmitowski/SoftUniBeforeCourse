using System;
using System.Linq;

namespace ZigZagArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] firstArr = new string[n];
            string[] secondArr = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] suppArray = Console.ReadLine().Split();

                string firstElement = suppArray[0];
                string secondElement = suppArray[1];

                if (i%2==0)
                {
                    firstArr[i] = firstElement;
                    secondArr[i] = secondElement;
                }
                else
                {
                    firstArr[i] = secondElement;
                    secondArr[i] = firstElement;
                }

            }

            Console.WriteLine(string.Join(" ",firstArr));
            Console.WriteLine(string.Join(" ",secondArr));


        }
    }
}
