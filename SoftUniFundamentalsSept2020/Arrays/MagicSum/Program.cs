using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                int curr = arr[i];
                for (int j = i+1; j < arr.Length; j++)
                {
                   
                    if (curr + arr[j] == number)
                    {
                        Console.WriteLine($"{curr} {arr[j]}");
                        break;
                    }

                }

            }

        }
    }
}
