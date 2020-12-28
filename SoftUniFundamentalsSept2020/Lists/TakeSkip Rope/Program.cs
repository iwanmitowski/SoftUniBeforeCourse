using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeSkip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();
            List<string> nonNumbers = new List<string>();
            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            StringBuilder result = new StringBuilder();

            int length = input.Length;

            for (int i = 0; i < length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    int number = int.Parse(input[i].ToString());
                    numbers.Add(number);
                    
                }
                else
                {
                    nonNumbers.Add(input[i].ToString());
                    
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i%2==0)
                {
                    take.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }

            

            
            int skipCount = 0;

            //input //skipTest_String044170
            for (int i = 0; i < take.Count; i++)
            {
                List<string> temp = nonNumbers;

                temp = temp.Skip(skipCount).Take(take[i]).ToList();

                result.Append(string.Join("", temp));

                skipCount += take[i] + skip[i];


            }
            
            Console.WriteLine(result.ToString());
            

            


        }
    }
}
