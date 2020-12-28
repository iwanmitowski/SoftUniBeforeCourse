using System;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            int vowelCounter = VowelCounter(input);
            Console.WriteLine(vowelCounter);

        }

        static int VowelCounter(string input)
        {
            int vowelCounter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {          
                    
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        vowelCounter++;
                        break;
                    default:
                        break;
                }
            }


            return vowelCounter;
        }
    }
}
