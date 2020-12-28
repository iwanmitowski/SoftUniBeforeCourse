using System;
using System.Linq;

namespace DifferenceOfArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] number2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = 0;

            bool areNotIdentical = false;

            for (int i = 0; i < number1.Length; i++)
            {
                sum += number1[i];
                if (number1[i] != number2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    areNotIdentical = true;
                    break;
                }
                

            }
            if (!areNotIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
                
            
           
            


        }
    }
}
