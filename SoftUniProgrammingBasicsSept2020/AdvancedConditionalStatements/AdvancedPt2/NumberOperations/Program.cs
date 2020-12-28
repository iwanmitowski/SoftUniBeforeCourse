using System;

namespace NumberOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string function = Console.ReadLine();

            double result = 0;
            if ((function == "/" || function == "%"))
            {

                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
            }
            if (function == "/" || function == "%")
            {
                if (function == "/" && n2 != 0)
                {
                    result = n1 / n2;
                    Console.WriteLine($"{n1} {function} {n2} = {result:f2}");
                }
                if (function == "%" && n2 != 0)
                {
                    result = n1 % n2;
                    Console.WriteLine($"{n1} {function} {n2} = {result}");
                }
            }
            if (function=="+" || function == "-"|| function == "*")
            {
                if (function=="+")
                {
                    result = n1 + n2;
                    if (result%2==0)
                    {
                        Console.WriteLine($"{n1} {function} {n2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {function} {n2} = {result} - odd");
                    }
                }
                if (function == "-")
                {
                    result = n1 - n2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {function} {n2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {function} {n2} = {result} - odd");
                    }
                }
                if (function == "*")
                {
                    result = n1 * n2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{n1} {function} {n2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{n1} {function} {n2} = {result} - odd");
                    }
                }

            }

        }
    }
}
