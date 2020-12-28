using System;
using System.Globalization;

namespace SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            bool isFound = false;
            int combinationCount = 0;


            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    combinationCount++;
                    if (i + j == magicNumber)
                    {

                        isFound = true;
                        Console.WriteLine($"Combination N:{combinationCount} ({i} + {j} = {magicNumber})");


                    }
                    if (i + j != magicNumber)
                    {


                        continue;
                    }

                }
                if (isFound)
                {

                    break;
                }


            }

            if (!isFound)
            {
                Console.WriteLine($"{combinationCount} combinations - neither equals {magicNumber}");
            }

            



        }
    }
}
