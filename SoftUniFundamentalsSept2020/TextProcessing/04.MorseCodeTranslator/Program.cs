using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> morseAlphabet = new List<string>() { "·−", "−···", "-·−·", "−··", "·", "··−·", "−−·", "····", "..", "·−−−", "−·−", "·−··", "−−", "−·", "−−−", "·−−·", "−−·−", "·−·", "···", "−", "··−", "···−", "·−−", "−··−", "−·−−", "−−··" };
            string fixingMorse = string.Join(" ", morseAlphabet);
            fixingMorse = fixingMorse.Replace('·', '.');
            fixingMorse = fixingMorse.Replace('−', '-');

            List<string> fixedMorse = fixingMorse.Split().ToList();

            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string[] input = Console.ReadLine().Split();
            string result = string.Empty;
            int counter = 0;
            for (int j = 0; j < fixedMorse.Count; j++)
            {
                for (int i = counter; i < input.Length; i++)
                {
                    counter++;
                    if (input[i] == "|")
                    {
                        result += " ";
                        break;
                    }
                    else if (fixedMorse.Contains(input[i]))
                    {
                        int indexOfMorse = fixedMorse.IndexOf(input[i]);
                        char letter = alphabet[indexOfMorse + 1];
                        result += letter;
                        
                        break;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
