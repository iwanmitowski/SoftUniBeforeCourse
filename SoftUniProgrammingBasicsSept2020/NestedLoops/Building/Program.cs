using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int i = floors; i >= 1; i--)
            {
                for (int k = 1; k <= rooms; k++)
                {
                    if (i % 2 == 0)
                    {
                        if (i == floors)
                        {
                            Console.Write($"L{i}{k - 1} ");
                        }
                        else
                        Console.Write($"O{i}{k - 1} ");
                        
                    }
                    else
                    {
                        
                        if (i==floors)
                        {
                            Console.Write($"L{i}{k - 1} ");
                        }
                        else
                        {
                            Console.Write($"A{i}{k - 1} ");
                        }
                        
                    }


                    
                }
                Console.WriteLine();
            }
        }
    }
}
