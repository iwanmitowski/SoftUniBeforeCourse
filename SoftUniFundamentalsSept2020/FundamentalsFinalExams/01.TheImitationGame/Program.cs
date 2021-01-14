using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();

            string[] commands = Console.ReadLine().Split("|");
            while (commands[0] != "Decode")
            {
                string action = commands[0];

                if (action == "Move")
                {
                    int number = int.Parse(commands[1]);
                    string substring = code.Substring(0, number);
                    code = code.Remove(0, number);
                    code += substring;
                }
                else if (action == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    string value = commands[2];

                    if (index>0||index<code.Length)
                    {
                        code = code.Insert(index, value);
                    }
                }
                else if (action == "ChangeAll")
                {
                    string oldStr = commands[1];
                    string newStr = commands[2];

                    code = code.Replace(oldStr, newStr);
                }

                commands = Console.ReadLine().Split("|");
            }
            Console.WriteLine($"The decrypted message is: {code}");

        }
    }
}
