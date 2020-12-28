using System;
using System.Collections.Generic;
using System.Linq;

namespace Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> drums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            List<int> result = new List<int>(drums); //Така за да не взима от heap-а стойността на drums!

            string command = Console.ReadLine();
            while (command!="Hit it again, Gabsy!")
            {
                int hit = int.Parse(command);

               

                for (int i = 0; i < drums.Count; i++)
                {
                    result[i] -= hit;
                    double possibleTransaction = savings - drums[i] * 3;

                    if (result[i] <=0 && possibleTransaction > 0)
                    {
                        result[i] = drums[i];
                        savings -= drums[i] * 3;
                    }
                    else if (result[i] <= 0 && possibleTransaction <= 0)
                    {
                        drums.RemoveAt(i);
                        result.RemoveAt(i);
                        i--;
                    }
                }



                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",result));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
