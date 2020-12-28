using System;
using System.Linq;

namespace TopInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int currentNumber = 0;
            bool isBigger = true;

            for (int i = 0; i < arr.Length; i++)
            {
                currentNumber = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {

                    if (currentNumber <= arr[j])
                    {
                        isBigger = false;
                        break;
                    }
                    else
                    {
                        isBigger = true;
                        
                    }

                }
                if (isBigger)
                {
                    
                    Console.Write(currentNumber+" ");
                }
                //else if (currentNumber == arr[arr.Length - 1])
                //{
                //    Console.Write(currentNumber + " ");
                //}

                isBigger = true;
            }

            
        }
    }
}
