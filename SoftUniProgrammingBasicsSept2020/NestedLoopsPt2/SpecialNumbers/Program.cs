using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isSpecial = true;

            for (int i = 1111; i <= 9999; i++)
            {
                string currentNum = i.ToString();
                isSpecial = true;
                for (int j = 0; j < currentNum.Length; j++)
                {
                    int digit = int.Parse(currentNum[j].ToString());

                    if (digit==0|| number%digit!=0)
                    {
                        isSpecial = false;
                        break;
                    }
                   
                }
                if (isSpecial)
                {
                    Console.WriteLine($"{currentNum}");
                }
            }
        }
    }
}
