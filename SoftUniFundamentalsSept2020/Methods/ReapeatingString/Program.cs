using System;
using System.Text;

namespace ReapeatingString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = RepeatString(text, count);
            Console.WriteLine(result);

        }

        static string RepeatString(string text, int count)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                result.Append(text);
            }

            return result.ToString();
        }
    }
}
