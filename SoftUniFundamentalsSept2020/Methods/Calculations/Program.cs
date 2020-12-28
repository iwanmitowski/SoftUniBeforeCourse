using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string activity = Console.ReadLine();
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            Calculation(activity, n1, n2);
        }

        static void Calculation(string activity, int number1, int number2)
        {
            double sum = 0;
            if (activity=="add")
            {
                sum = number1 + number2;

            }
            else if (activity=="multiply")
            {
                sum = number1 * number2;
            }
            else if (activity=="substract")
            {
                sum = number1 - number2;
            }
            else if (activity == "divide")
            {
                sum = number1 / number2;
            }
            Console.WriteLine(sum);
        }

    }
}
