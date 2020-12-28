using System;
using System.ComponentModel.DataAnnotations;

namespace BiggerNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            //int maxNum = int.MinValue;

            //while (true)
            //{
            //    string input = Console.ReadLine();

            //    if (input == "Stop")
            //    {
            //        break;
            //    }

            //    int number = int.Parse(input);

            //    if (number>maxNum)
            //    {
            //        maxNum = number;
            //    }
            //}
            //Console.WriteLine(maxNum);

            int minNum = int.MaxValue;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop")
                {
                    break;
                }

                int number = int.Parse(input);

                if (number < minNum)
                {
                    minNum = number;
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
