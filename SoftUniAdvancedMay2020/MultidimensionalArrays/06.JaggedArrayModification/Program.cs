using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] jagged = new int[size][];

            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string[] input = Console.ReadLine().Split();
            while (input[0]!="END")
            {
                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row<0 || row>=size || col<0 || col>=jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine().Split();
                    continue;
                }


                if (command == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (command=="Subtract")
                {
                    jagged[row][col] -= value;
                }


                input = Console.ReadLine().Split();
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ",jagged[i]));
            }

        }
    }
}
