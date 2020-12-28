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
            Console.Write("Write number of commands: ");
            int n = int.Parse(Console.ReadLine());
            string[] command = new string[3];  //има възможност за replace да са 3 (replace,index,дума)
            for (int i = 0; i < n; i++)
            {
                command = Console.ReadLine().Split().ToArray();
                
                LoopingTheCommand(command, arr);
                arr = LoopingTheCommand(command, arr).ToArray();
            }
            
            PrintingTheResult(arr);
            
            





        }


        //string currCommand = string.Empty;

        //int index = 0;
        //string wordToReplace = string.Empty;



        //for (int i = 0; i < n; i++)
        //{

        //    command = Console.ReadLine().Split().ToArray();
        //    if (command.Length>1)
        //    {
        //        currCommand = command[0];
        //        index = int.Parse(command[1]);
        //        wordToReplace = command[2];
        //        arr[index] = wordToReplace;

        //    }
        //    else
        //    {
        //        currCommand = command[0];
        //        if (currCommand=="Reverse")
        //        {
        //            arr = arr.Reverse().ToArray();
        //        }
        //        if (currCommand=="Distinct")
        //        {
        //            arr = arr.Distinct().ToArray();

        //        }
        //    }

        //}
        //Console.WriteLine(string.Join(", ", arr));

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

        static string[] LoopingTheCommand(string[]command,string[] arr)
        {
            
                if (command[0]=="Reverse")
                {
                    arr = DistinctAndReverseMethod(command, arr).ToArray();
                }
                else if (command[0] == "Distinct")
                {
                    arr = DistinctAndReverseMethod(command, arr).ToArray();
                }
                else if(command[0]=="Replace")
                {
                    arr = ReplaceMethod(command, arr).ToArray();
                }
            
            return arr;
        }

        static void PrintingTheResult(string[]arr)
        {
            Console.WriteLine(string.Join(" ", arr));

        }




    }
    



}

