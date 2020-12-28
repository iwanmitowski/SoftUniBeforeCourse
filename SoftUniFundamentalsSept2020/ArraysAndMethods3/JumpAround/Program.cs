using System;
using System.Linq;

namespace JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int jump = arr[0];
            int sum = arr[0];
            int lastindex = 0;

            //Working for the given tests.
            //for (int i = jump; i < arr.Length; i += jump)
            //{
            //    sum += arr[i];

            //    jump = arr[jump];
            //    lastindex = i;
            //}
            //for (int j = lastindex; j > 0; j -= jump)
            //{
            //    sum += arr[j - jump];
            //    jump = arr[j - jump];
            //    if (j - jump <= 0)
            //    {
            //        break;
            //    }
            //}

            while (true)
            {
                if (lastindex + jump < arr.Length)
                {
                    lastindex += jump;
                }
                else if (lastindex - jump >= 0)
                {
                    lastindex -= jump;
                }
                else
                {
                    break;
                }
                sum += arr[lastindex];
                jump = arr[lastindex];
            }
            Console.WriteLine(sum);
        }
    }
}


