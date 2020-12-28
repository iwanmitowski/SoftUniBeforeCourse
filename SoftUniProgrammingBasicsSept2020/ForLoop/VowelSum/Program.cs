using System;

namespace VowelSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int vowel = 0;
            for (int i = 0; i < word.Length; i++)
            {
                switch (word[i])
                {
                    case 'a':
                        vowel += 1;
                            break;
                    case 'e':
                        vowel += 2;
                        break;
                    case 'i':
                        vowel += 3;
                        break;
                    case 'o':
                        vowel += 4;
                        break;
                    case 'u':
                        vowel += 5;
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine(vowel);
        }
    }
}
