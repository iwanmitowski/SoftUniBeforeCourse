using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> opening = new Stack<char>();

            bool isBalanced = true;

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    opening.Push(c);
                }
                else 
                {
                    if (opening.Any()==false)
                    {
                        isBalanced = false;

                    }
                    char currOpen = opening.Pop();
                    bool isBalancedRound = currOpen == '(' && c == ')';
                    bool isBalancedSquare = currOpen == '[' && c == ']';
                    bool isBalancedJagged = currOpen == '{' && c == '}';

                    if (isBalancedRound==false && isBalancedSquare==false && isBalancedJagged== false)
                    {
                        isBalanced = false;
                        break;
                    }
                    
                }
                
            }
            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }




        }
    }
}
