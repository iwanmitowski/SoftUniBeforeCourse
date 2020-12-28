using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(SmallestNumber(3));

        }

        static int SmallestNumber(int number)
        {
            int smallestNumber = int.MaxValue;
            

            for (int i = 0; i < number; i++)
            {
               int num = int.Parse(Console.ReadLine());
                if (num<smallestNumber)
                {
                    smallestNumber = num;
                }

            }
            return smallestNumber;
        }
    }
}
