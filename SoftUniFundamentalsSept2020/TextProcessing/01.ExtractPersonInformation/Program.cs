using System;
using System.Text;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int nameStartIndex = input.IndexOf('@')+1;
                int nameEndIndex = input.IndexOf('|');

                string name = input.Substring(nameStartIndex, nameEndIndex - nameStartIndex);

                int ageStartIndex = input.IndexOf('#') + 1;
                int ageEndIndex = input.IndexOf('*');

                string age = input.Substring(ageStartIndex, ageEndIndex - ageStartIndex);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
