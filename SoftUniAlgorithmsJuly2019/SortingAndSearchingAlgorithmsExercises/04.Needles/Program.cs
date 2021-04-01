using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Needles
{

    class Program
    {
        static List<int> indices = new List<int>();

        static void Main(string[] args)
        {
            int[] cn = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] spots = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] needles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var needle in needles)
            {
                bool match = false;

                for (int i = 0; i < spots.Length; i++)
                {
                    if (spots[i] >= needle)
                    {
                        match = true;
                        ReturnIndex(spots, i - 1);
                        break;
                    }

                }

                if (match==false)
                {
                    ReturnIndex(spots, spots.Length - 1);
                }

            }
            Console.WriteLine(string.Join(" ", indices));


        }

        private static void ReturnIndex(int[] spots, int i)
        {

            while (i >= 0)
            {
                if (spots[i] != 0)
                {
                    indices.Add(i + 1);
                    return;
                }

                i--;
            }
            indices.Add(0);
           
        }
    }
}

