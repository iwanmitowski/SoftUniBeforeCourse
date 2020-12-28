using System;

namespace NumbersPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int nestedNumber = 0;
            bool isEqual = false;
            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <=i; j++)
                {
                    nestedNumber++;
                    if (j<=i)
                    {
                        Console.Write($"{nestedNumber} ");
                        
                        
                        
                    }
                    if (nestedNumber == num)
                    {
                        isEqual = true;
                        break;
                    }

                }
                if (isEqual)
                {
                    break;
                }
                Console.WriteLine();
            }

        }
    }
}
