using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(numbers,(x,y)=>{

                int comparator = 0;
                if (x%2==0 && y%2!=0)
                {
                    comparator = -1;
                }
                else if (x%2!=0&&y%2==0)
                {
                    comparator = 1;
                }
                else
                {
                    comparator = x.CompareTo(y);
                }
                return comparator;
            });
            Console.WriteLine(string.Join(" ",numbers));

        }
    }
}
