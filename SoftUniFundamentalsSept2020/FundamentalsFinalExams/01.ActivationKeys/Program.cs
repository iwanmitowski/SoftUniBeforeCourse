using System;
using System.Linq;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string[] input = Console.ReadLine().Split(">>>");
            int startIndex = 0;
            int endIndex = 0;
            
            
            while (input[0] != "Generate")
            {
                string command = input[0];
                bool isNotFound = true;

                if (command == "Slice")
                {
                    startIndex = int.Parse(input[1]);
                    endIndex = int.Parse(input[2]);
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);

                }
                else if (command == "Flip")
                {
                    string upperLower = input[1];
                    startIndex = int.Parse(input[2]);
                    endIndex = int.Parse(input[3]);
                    string sub = string.Empty;
                    if (upperLower=="Upper")
                    {
                        sub = activationKey.Substring(startIndex, endIndex - startIndex).ToUpper();
                    }
                    else
                    {
                        sub = activationKey.Substring(startIndex, endIndex - startIndex).ToLower();
                    }
                    activationKey = activationKey.Replace(activationKey.Substring(startIndex, endIndex - startIndex), sub);
                    Console.WriteLine(activationKey);

                }
                else if (command=="Contains")
                {
                    string subString = input[1];
                    if (activationKey.Contains(subString))
                    {
                        Console.WriteLine($"{activationKey} contains {subString}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                        isNotFound = true;
                    }
                }
                if (isNotFound==false)
                {
                    Console.WriteLine(activationKey);
                }
                
               

                input = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
