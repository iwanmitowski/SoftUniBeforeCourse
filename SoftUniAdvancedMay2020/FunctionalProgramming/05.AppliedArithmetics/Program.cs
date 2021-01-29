using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> addFunc = n => n + 1;
            Func<int, int> multiFunc = n => n * 2;
            Func<int, int> subtractFunc = n => n - 1;
            Action<int[]> printFunc = nums => Console.WriteLine(string.Join(" ", nums));

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(addFunc).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(multiFunc).ToArray();

                        break;
                    case "subtract":
                        numbers = numbers.Select(subtractFunc).ToArray();

                        break;
                    case "print":
                        printFunc(numbers);
                        break;

                    default:
                        break;
                }


                command = Console.ReadLine();
            }




        }
    }
}
