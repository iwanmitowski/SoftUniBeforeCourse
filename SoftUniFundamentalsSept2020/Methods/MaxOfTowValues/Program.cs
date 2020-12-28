using System;
using System.Dynamic;

namespace MaxOfTowValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            if (type == "int")
            {
                int firstInt = int.Parse(input1);
                int secondInt = int.Parse(input2);
                int resultInt = GetMaxInt(firstInt, secondInt);
                Console.WriteLine(resultInt);
            }
            else if (type=="char")
            {
                char firstChar = char.Parse(input1);
                char secondChar = char.Parse(input2);
                char resultChar = GetMaxChar(firstChar, secondChar);
                Console.WriteLine(resultChar);
            } 
            else if (type== "string")
            {
                string firstString = input1;
                string secondString = input2;
                string resultString = GetMaxString(firstString, secondString);
                Console.WriteLine(resultString);
            }

        }

         static int GetMaxInt(int input1, int input2)
        {
            return Math.Max(input1, input2);
        }
        public static char GetMaxChar(char input1, char input2)
        {
            return (char) Math.Max(input1, input2); // cast-ване
        }
        public static string GetMaxString(string input1, string input2)
        {
            int comparison = input1.CompareTo(input2);
            if (comparison > 0)
            {
                return input1;
            }
            else
            {
                return input2;
            }
        }
    }
}
