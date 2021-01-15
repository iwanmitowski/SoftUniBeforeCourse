using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();



            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    int indexStart =stack.Pop();
                    Console.WriteLine(input.Substring(indexStart,i-indexStart+1));
                }
            }
            


        }
    }
}
