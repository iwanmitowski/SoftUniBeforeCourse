using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace Pascal_s_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("1");
            if (n==1)
            {
                Environment.Exit(0);

            }

            int[] arr = new int[] { 1, 1 };
            Console.WriteLine(string.Join(" ",arr));

            if (n==2)
            {
                Environment.Exit(0);
            }

            for (int i = 0; i < arr.Length+1; i++)
            {
                int[] currentArr = new int[arr.Length + 1];
                currentArr[0] = 1;
                currentArr[currentArr.Length - 1] = 1;

                for (int j = 1; j < currentArr.Length-1 ; j++)
                {
                    currentArr[j] = arr[j - 1] + arr[j];

                }
                arr = currentArr;
                Console.WriteLine(string.Join(" ",arr));
                if (n==arr.Length)
                {
                    break;
                }




            }



        }
    }
}
