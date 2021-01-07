using System;

namespace _02.AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string sequence = Console.ReadLine();

            int sum = 0;

            foreach (var c in sequence)
            {
                if ((int)c > Math.Min((int)firstChar, (int)secondChar) && (int)c < Math.Max((int)firstChar, (int)secondChar))
                {
                    sum += (int)c;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
