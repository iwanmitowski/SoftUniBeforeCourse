using System;
using System.Linq;

namespace ManipulateArray
{
    class Program
    {

        static void Main(string[] args)
        {
            //TO DO:
            //метод за всяка команда
            //метод да чете командата и да извиква метода за командата

            Console.Write("Write your array: ");
            string[] arr = Console.ReadLine().Split();
            
            string[] command = new string[3];  //има възможност за replace да са 3 (replace,index,дума)
            while (true)
            {
                command = Console.ReadLine().Split().ToArray();
                if (command[0]=="END")
                {
                    break;
                }
                if (command[0]!="Distinct"|| command[0] != "Reverse"|| command[0] != "Replace")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                if (command.Length>1 && (int.Parse(command[1])>arr.Length || int.Parse(command[1]) < 0))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                LoopingTheCommand(command, arr);
                arr = LoopingTheCommand(command, arr).ToArray();
            }
               
            

            PrintingTheResult(arr);
        }
        static string[] DistinctAndReverseMethod(string[] command, string[] arr)
        {
            if (command[0] == "Reverse")
            {
                return arr.Reverse().ToArray();

            }
            else if (command[0] == "Distinct")
            {
                return arr.Distinct().ToArray();
            }
            return arr;
        }

        static string[] ReplaceMethod(string[] command, string[] arr)
        {
            int index = int.Parse(command[1]);
            string wordToReplace = command[2];
            arr[index] = wordToReplace;

            return arr;
        }

        static string[] LoopingTheCommand(string[] command, string[] arr)
        {

            if (command[0] == "Reverse")
            {
                arr = DistinctAndReverseMethod(command, arr).ToArray();
            }
            else if (command[0] == "Distinct")
            {
                arr = DistinctAndReverseMethod(command, arr).ToArray();
            }
            else if (command[0] == "Replace")
            {
                arr = ReplaceMethod(command, arr).ToArray();
            }

            return arr;
        }

        static void PrintingTheResult(string[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));

        }
    }

}