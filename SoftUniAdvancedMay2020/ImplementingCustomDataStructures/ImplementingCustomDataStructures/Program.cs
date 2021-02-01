using System;

namespace ImplementingCustomDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CustomList:");

            CustomList myList = new CustomList();
            myList.Add(0);
            myList.Add(100);
            Console.WriteLine(myList.Contains(0));
            Console.WriteLine(myList.Contains(1000));
            myList.Insert(0, 1);
            myList.Swap(0, 1);
            myList.Add(666);
            Console.WriteLine("List:");
            Console.WriteLine(myList);

            Console.WriteLine("CustomStack:");

            CustomStack myStack = new CustomStack();
            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);
            Console.WriteLine($"Removing last element {myStack.Pop()}");
            Console.WriteLine($"Count:{myStack.Count}");
            Console.WriteLine($"Last element {myStack.Pop()}");
            Console.WriteLine($"Count:{myStack.Count}");
            myStack.ForEach(x => Console.WriteLine(x));


        }
    }
}
