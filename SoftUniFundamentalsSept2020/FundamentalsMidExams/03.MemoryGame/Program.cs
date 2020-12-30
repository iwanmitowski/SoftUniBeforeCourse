using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] input = Console.ReadLine()
                .Split();

            int moves = 0;

            while (input[0] != "end")
            {
                int index1 = int.Parse(input[0]);
                int index2 = int.Parse(input[1]);
                moves++;
                if (index1==index2||index1<0||index1>=sequence.Count||index2<0||index2>=sequence.Count)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    sequence.Insert(sequence.Count / 2, $"-{moves}a");
                    sequence.Insert(sequence.Count / 2, $"-{moves}a");

                    input = Console.ReadLine()
                .Split();
                    continue;
                }

                if (sequence[index1]==sequence[index2])
                {
                    string number = sequence[index1];
                    sequence.RemoveAt(Math.Min(index1,index2));
                    sequence.RemoveAt(Math.Max(index1,index2)-1);
                    Console.WriteLine($"Congrats! You have found matching elements - {number}!");
                    if (sequence.Count == 0)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                input = Console.ReadLine()
                .Split();
            }
            if (sequence.Count==0)
            {
                Console.WriteLine($"You have won in {moves} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ",sequence));
            }

        }
    }
}
