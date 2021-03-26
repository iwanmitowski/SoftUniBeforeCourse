using System;
using System.Linq;

namespace _02.Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int number = int.Parse(Console.ReadLine());

           int index =  IndexOutOf(array, number, 0, array.Length - 1);
            Console.WriteLine(index);
        }

        private static int IndexOutOf(int[] array, int number, int low, int high)
        {
            int mid = low + (high - low) / 2;

            while (low <= high)
            {
                if (number < array[mid])
                {
                    return IndexOutOf(array, number, low, mid - 1);
                }
                else if (number > array[mid])
                {
                    return IndexOutOf(array, number, mid + 1, high);
                }
                else
                {
                    return mid;
                }

            }

            return -1;
        }
    }
}
