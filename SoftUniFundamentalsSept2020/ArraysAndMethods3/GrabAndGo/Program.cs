using System;
using System.Linq;

namespace GrabAndGo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            int lastNIndex = Array.LastIndexOf(arr, n);
            int sum = 0;
            bool isSimilar = false;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]==n)
                {
                    isSimilar = true;

                }

            }

            for (int i = 0; i < lastNIndex; i++)
            {
                sum += arr[i]; 
            }
           
            if (!isSimilar)
            {
                Console.WriteLine("No occurrences were found!");
            }
            else
            {
                Console.WriteLine(sum);
            }
        }
    }
}
