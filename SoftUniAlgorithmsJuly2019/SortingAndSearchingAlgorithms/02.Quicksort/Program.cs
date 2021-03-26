using System;

namespace _02.Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 4, 3, 2, 1 };

            QuickSorter(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ",arr));
        }

        private static void QuickSorter(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(arr, lo, hi);

                QuickSorter(arr, lo, p - 1);
                QuickSorter(arr,p + 1,hi);
            }

        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[hi];
            int i = (lo - 1);

            for (int j = lo; j <= hi - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int t = arr[i];
                    arr[i] = arr[j];
                    arr[j] = t;
                    
                }
            }

            int t2 = arr[i + 1];
            arr[i + 1] = arr[hi];
            arr[hi] = t2;
            
            return (i + 1);

        }

    }
}
