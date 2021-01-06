using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            StringBuilder sb = new StringBuilder();



            foreach (var c in input)
            {
                sb.Append((char)(c + 3));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
