using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> myStack = new CustomStack<int>();

            string[] input = Console.ReadLine().Split(new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (input[0]!="END")
            {
                try
                {
                    if (input[0] == "Push")
                    {
                        foreach (var item in input.Skip(1))
                        {
                            myStack.Push(int.Parse(item));
                        }
                    }
                    else if (input[0] == "Pop")
                    {

                        myStack.Pop();
                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                

                input = Console.ReadLine().Split(new[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            

            foreach (var item in myStack)
            {
                Console.WriteLine(item);

            }
        }
    }
}
