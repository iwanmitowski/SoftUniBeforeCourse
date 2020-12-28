using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //int x1, x2, x3 = 0;
            int count = 0;
            bool finish = false;
            while (true)
            {
               
                for (int x1 = 0; x1 <= n; x1++)
                {
                    for (int x2 = 0; x2 <= n; x2++)
                    {
                        for (int x3 = 0; x3 <= n; x3++)
                        {
                            if (x1 + x2 + x3 == n)
                            {
                                count++;
                                finish = true;
                                if (n < 0)
                                {
                                    break;
                                }
                                break;

                            }
                        }
                    }
                }
                if (finish)
                {
                    Console.WriteLine(count);
                    break;
                }
            }
        }
    }
}
