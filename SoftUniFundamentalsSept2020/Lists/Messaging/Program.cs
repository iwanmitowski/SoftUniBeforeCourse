using System;
using System.Collections.Generic;
using System.Linq;

namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {


            List<string> numbers = Console.ReadLine()
                .Split()
                .ToList();

            string text = Console.ReadLine();

            List<char> result = new List<char>();


            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                string number = numbers[i];
                int length = number.Length;


                for (int j = 0; j < length; j++)
                {
                    int curr = int.Parse(number) % 10;
                    number = number.Remove(number.Length - 1);
                    sum += curr;
                }

                
                if (sum > text.Length)
                {
                    sum -= text.Length;

                    result.Add(text[sum]);

                }
                else
                {

                    result.Add(text[sum]);
                }

                text = text.Remove(sum, 1);

                
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
