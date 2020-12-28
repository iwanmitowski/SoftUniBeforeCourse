using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sumOfAllRemoved = 0;
            int element = 0;
            while (input.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    index = 0;
                    element = input[index];
                    sumOfAllRemoved += element;
                    input.RemoveAt(0);
                    if (input.Count == 0)
                    {
                        break;
                    }
                    input.Insert(0, input[input.Count - 1]);


                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] <= element)
                        {

                            input[i] += element;
                        }
                        else
                        {
                            input[i] -= element;
                        }
                    }
                }
                else if (index > input.Count - 1)
                {
                    index = input.Count - 1;
                    element = input[index];
                    sumOfAllRemoved += element;
                    input.RemoveAt(input.Count - 1);
                    if (input.Count == 0)
                    {
                        break;
                    }
                    input.Add(input[0]);


                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] <= element)
                        {

                            input[i] += element;
                        }
                        else
                        {
                            input[i] -= element;
                        }
                    }
                }
                else
                {

                    element = input[index];
                    sumOfAllRemoved += element;
                    input.RemoveAt(index);
                    if (input.Count == 0)
                    {
                        break;
                    }
                    for (int i = 0; i < input.Count; i++)
                    {
                        if (input[i] <= element)
                        {

                            input[i] += element;
                        }
                        else
                        {
                            input[i] -= element;
                        }
                    }
                }

            }
            Console.WriteLine(sumOfAllRemoved);
        }
    }
}
