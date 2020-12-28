using System;
using System.Runtime.ConstrainedExecution;

namespace AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = SumNum1Num2(num1, num2,num3);

            Console.WriteLine(sum);
        }

        static int SumNum1Num2(int num1, int num2,int num3) // TRICKY PART!!!
        {
            int sum = num1 + num2 ;
            return Substract(sum,num3);
        }

        static int Substract(int sum, int num3)
        {
            int finalResult = sum - num3;
            return finalResult;
        }

    }
}
