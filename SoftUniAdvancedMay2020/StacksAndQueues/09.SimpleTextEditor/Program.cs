using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> previousText = new Stack<string>();
            previousText.Push(text.ToString());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                string command = commands[0];

                if (command=="1")
                {
                    string someString = commands[1];
                    text.Append(someString);
                    previousText.Push(text.ToString());

                }
                else if (command=="2")
                {
                    int count = int.Parse(commands[1]);
                    text.Remove(text.Length - count,count);
                    previousText.Push(text.ToString());
                }
                else if (command=="3")
                {
                    int index = int.Parse(commands[1])-1;
                    Console.WriteLine(text[index]);
                }
                else if (command=="4")
                {
                    previousText.Pop();
                    text = new StringBuilder();
                    text.Append(previousText.Peek());
                }



            }


        }
    }
}
