using System;

namespace CustomStack
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new string[] { "1", "2" });
            Console.WriteLine(stack.IsEmpty());

        }
    }
}
