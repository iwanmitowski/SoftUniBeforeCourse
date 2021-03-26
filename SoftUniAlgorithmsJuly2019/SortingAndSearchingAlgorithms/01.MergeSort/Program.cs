using System;

namespace _01.MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 4, 3, 2, 1 };
            
            MergeSorter(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void MergeSorter(int[] arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            int m = l + (r - l) / 2;
            MergeSorter(arr, l, m);
            MergeSorter(arr, m + 1, r);
            Merge(arr, l, m, r);

        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                L[i] = arr[l + i];
            }
            for (int j = 0; j < n2; j++)
            {
                R[j] = arr[m + 1 + j];
            }

            int indFirst = 0;
            int indSecond = 0;
            int indMerged = l;

            while (indFirst < n1 && indSecond < n2)
            {
                if (L[indFirst] <= R[indSecond])
                {
                    arr[indMerged] = L[indFirst];
                    indFirst++;
                }
                else
                {
                    arr[indMerged] = R[indSecond];
                    indSecond++;
                }
                indMerged++;
            }

            while (indFirst < n1)
            {
                arr[indMerged] = L[indFirst];
                indFirst++;
                indMerged++;
            }

            while (indSecond < n2)
            {
                arr[indMerged] = R[indSecond];
                indSecond++;
                indMerged++;
            }
        }
    }
}
