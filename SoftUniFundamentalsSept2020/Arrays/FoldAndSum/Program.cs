using System;
using System.Linq;
namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(6/(2*(1+2)));
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftIndex = arr.Length / 4 - 1;
            int rightIndex = 3 * arr.Length / 4;
            int numbers = 0;

            int[] topArr = new int[arr.Length / 2];
            int[] botArr = new int[arr.Length / 2];

            for (int i = leftIndex; i >= 0; i--)
            {
                numbers++;
                topArr[leftIndex - i] = arr[i];
            }
            for (int i = arr.Length-1; i >= rightIndex; i--)
            {
                
                topArr[arr.Length-1 - i+numbers] = arr[i];
                
            }

            for (int i = leftIndex+1; i < rightIndex; i++)
            {
                botArr[i-numbers]= arr[i];
            }

            for (int i = 0; i < topArr.Length; i++)
            {
                Console.Write(topArr[i]+botArr[i]+" ");
            }

        }
    }
}