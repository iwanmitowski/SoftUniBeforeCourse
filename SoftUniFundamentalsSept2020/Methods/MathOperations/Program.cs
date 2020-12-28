using System;
using System.Diagnostics.CodeAnalysis;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string action = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            int sum = Calculation(num1, num2, action);
            Console.WriteLine(sum);
        }

        static int Calculation(int num1, int num2, string action)
        {
            int sum = 0;

            if (action=="/")
            {
                sum = num1 / num2;
            }
            else if (action=="*")
            {
                sum = num1 * num2;
            }
            else if (action == "+")
            {
                sum = num1 + num2;
            }
            else if (action == "-")
            {
                sum = num1 - num2;
            }
            return sum;
        }
    }
}
