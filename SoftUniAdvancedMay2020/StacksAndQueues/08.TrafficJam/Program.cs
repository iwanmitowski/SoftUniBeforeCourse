using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> traffic = new Queue<string>();
            int counter = 0;

            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "green")
                {
                    if (traffic.Count > 0)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"{traffic.Dequeue()} passed!");
                            counter++;
                            if (traffic.Count == 0)
                            {
                                break;
                            }

                        }
                    }
                    else
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                }
                else
                {
                    traffic.Enqueue(input);
                }


                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
