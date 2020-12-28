using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Passes all zero tests 60/100





            List<string> input = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "3:1")
                {
                    break;
                }
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex < 0 || startIndex > input.Count - 1)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > input.Count - 1)
                    {
                        endIndex = input.Count - 1;
                    }

                    int counter = 0;

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        input[startIndex] += $"{input[i + 1]}";
                        counter++;

                    }
                    input.RemoveRange(startIndex + 1, counter);
                }
                // тука нещо гърми!
                if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int parts = int.Parse(command[2]);

                    if (index < 0 || index > input.Count - 1)
                    {
                        index = 0;
                    }
                    if (index > input.Count - 1)
                    {
                        index = input.Count - 1;
                    }


                    List<string> temp = new List<string>();
                    string word = input[index];
                    int partLength = word.Length / parts;
                    int bonusPartLength = word.Length % parts;


                    for (int i = 0; i < parts; i++)
                    {

                        if (i == parts - 1)
                        {
                            partLength += bonusPartLength;
                        }

                        temp.Add(word.Substring(0, partLength));
                        word = word.Remove(0, partLength);
                    }
                    input.RemoveAt(index);
                    input.InsertRange(index, temp);

                }

            }
            Console.WriteLine(string.Join(" ", input));

        }
    }
}






