using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> stack = new Stack<string>(input.Split().Reverse().ToArray());

            while (stack.Count>1)
            {
                int firstNum = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int secondNum = int.Parse(stack.Pop());
                int numberToAdd = 0;

                if (operation=="-")
                {
                    numberToAdd = firstNum - secondNum;
                    
                }
                else if (operation=="+")
                {
                    numberToAdd = firstNum + secondNum;
                    
                }
                stack.Push(numberToAdd.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
