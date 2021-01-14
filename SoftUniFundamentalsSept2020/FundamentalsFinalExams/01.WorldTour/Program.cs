using System;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(":");
            while (commands[0]!="Travel")
            {
                string command = commands[0];

                if (command=="Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    string substring = commands[2];

                    if (index<0||index>=text.Length)
                    {
                        commands = Console.ReadLine().Split(":");
                        continue;
                    }
                    else
                    {
                        text = text.Insert(index, substring);
                    }

                }
                else if (command=="Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    if ((startIndex >= 0) && (startIndex < text.Length) && (endIndex >= 0) && (endIndex < text.Length))
                    {
                        text = text.Remove(startIndex, endIndex - startIndex + 1);
                    }
                       
                }
                else if (command=="Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];
                    text = text.Replace(oldString, newString);
                }
                Console.WriteLine(text);

                commands = Console.ReadLine().Split(":");
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
