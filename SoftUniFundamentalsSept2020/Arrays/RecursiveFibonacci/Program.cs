using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //int[] arr = new int[50];
            //    arr[0] = 1;
            //    arr[1] = 1;

            //for (int i = 1; i < n; i++)
            //{
            //    arr[i+1] = arr[i - 1] + arr[i];

            //}

            //Console.WriteLine(arr[n-1]);

            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[50];
            
            int num = GetFibonacciNumber(arr, n);
            Console.WriteLine(num);
        }

        static int GetFibonacciNumber(int[] arr, int number)
        {
            for (int i = 0; i < number; i++)
            {
                arr[i] = GetFibonaciNumber1(i);

            }

            return arr[number - 1];


        }


        static int GetFibonaciNumber1(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return GetFibonaciNumber1(number-1) + GetFibonaciNumber1(number - 2);

        }

        






    }


    
}
