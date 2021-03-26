using System;
using System.Linq;

namespace _01.Sorting
{
    class Program
    {
        static int[] temp;
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            temp = new int[array.Length];

            Sorter(array, 0, array.Length - 1);

            Console.WriteLine(string.Join(" ", array));
        }

        private static void Sorter(int[] array, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int m = low + (high - low) / 2;

            Sorter(array, low, m);
            Sorter(array, m + 1, high);
            Merge(array, low, m, high);
        }

        private static void Merge(int[] array, int low, int m, int high)
        {
            if (IsLess(array[m], array[m + 1]))
            {
                return;
            }

            for (int k = low; k <= high; k++)
            {
                temp[k] = array[k];
            }


            int i = low;
            int j = m + 1;
            for (int index = low; index <= high; index++)
            {
                if (i > m)
                {
                    array[index] = temp[j++];
                }
                else if (j > high)
                {
                    array[index] = temp[i++];

                }
                else if (IsLess(temp[i], temp[j]))
                {
                    array[index] = temp[i++];
                }
                else
                {
                    array[index] = temp[j++];
                }

            }
        }
        private static bool IsLess(int i, int j)
        {
            return i.CompareTo(j) < 0;
        }
    }
}
