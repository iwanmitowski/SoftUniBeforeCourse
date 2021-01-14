using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string chat = Console.ReadLine();

            string[] command = Console.ReadLine().Split(":|:");
            while (command[0]!="Reveal")
            {
                string instruction = command[0];

                if (instruction=="InsertSpace")
                {
                    int index = int.Parse(command[1]);
                    chat = chat.Insert(index, " ");
                    Console.WriteLine(chat);
                }
                else if (instruction=="Reverse")
                {
                    string substring = command[1];
                    
                    if (chat.Contains(substring))
                    {
                        int indexOfSub = chat.IndexOf(substring);
                        char[] arr = substring.Reverse().ToArray();
                        substring = string.Join("", arr);
                        chat = chat.Remove(indexOfSub, substring.Length);
                        chat += substring;
                        Console.WriteLine(chat);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (instruction=="ChangeAll")
                {
                    string substring = command[1];
                    string replacement = command[2];

                    chat = chat.Replace(substring, replacement);
                    Console.WriteLine(chat);
                }



                command = Console.ReadLine().Split(":|:");
            }
            Console.WriteLine($"You have a new text message: {chat}");
        }
    }
}
