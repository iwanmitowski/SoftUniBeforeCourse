using System;
using System.Linq;

namespace _03.InversionsCount
{
    class Program
    {
        static int[] array;
        static void Main(string[] args)
        {
            array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(MergeSort(array, array.Length));


        }

        static int MergeSort(int[] arr, int arrSize)
        {
            int[] temp = new int[arrSize];
            return MergeSorter(arr, temp, 0, arrSize - 1);
        }
                
        private static int MergeSorter(int[] arr, int[] temp, int low, int high)
        {

            int count = 0;
            if (high > low)
            {
                int mid = (high + low) / 2;

                count += MergeSorter(arr, temp, low, mid);
                count += MergeSorter(arr, temp, mid + 1, high);

                count += Merge(arr, temp, low, mid + 1, high);
            }

            return count;
        }

        static int Merge(int[] arr, int[] temp, int l, int m, int r)
        {
            int i = l;
            int j = m;
            int k = l;

            int count = 0;

            while ((i <= m - 1) && (j <= r))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k] = arr[i];
                    k++;
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    k++;
                    j++;
                    count = count + (m - i);
                }
            }
            while (i <= m - 1)
            {
                temp[k] = arr[i];
                k++;
                i++;
            }
            while (j <= r)
            {
                temp[k] = arr[j];
                k++;
                j++;
            }

            for (int ind = l; ind <= r; ind++)
            {
                arr[ind] = temp[ind];
            }

            return count;
        }
    }
}
