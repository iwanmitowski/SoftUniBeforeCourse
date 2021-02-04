using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            string name = $"{firstInput[0]} {firstInput[1]}";
            Tuple<string, string> stringStringTuple = new Tuple<string, string>(name, firstInput[2]);
            Console.WriteLine(stringStringTuple);

            string[] secondInput = Console.ReadLine().Split();
            Tuple<string, int> stringIntTuple = new Tuple<string, int>(secondInput[0], int.Parse(secondInput[1]));
            Console.WriteLine(stringIntTuple);

            string[] thirdInput = Console.ReadLine().Split();
            Tuple<int, double> intDoubleTuple = new Tuple<int, double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));
            Console.WriteLine(intDoubleTuple);
        }
    }
}
