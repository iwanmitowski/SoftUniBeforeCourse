using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] input = Console.ReadLine()
                .Split();

            while (input[0]!="end")
            {
                string command = input[0];
                if (command == "decrease")
                {
                    array = array.Select(x => x - 1).ToList();

                    input = Console.ReadLine()
                .Split();
                    continue;
                }
                
                int index1 = int.Parse(input[1]);
                int index2 = int.Parse(input[2]);

                if (command=="swap")
                {
                    int index1Value = array[index1];
                    int index2Value = array[index2];

                    array[index1] = index2Value;
                    array[index2] = index1Value;
                    

                }
                if (command=="multiply")
                {
                    int index1Value = array[index1]* array[index2];
                    array[index1] = index1Value;
                }
                

                input = Console.ReadLine()
                .Split();
            }

            Console.WriteLine(string.Join(", ",array));
        }
    }
}
