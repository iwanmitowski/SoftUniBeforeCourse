using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> myList = null;

            string[] input = Console.ReadLine().Split();



            while (input[0] != "END")
            {

                try
                {
                    if (input[0] == "Create")
                    {
                        List<string> elements = input.Skip(1).ToList();
                        myList = new ListyIterator<string>(elements);

                    }
                    else if (input[0] == "Move")
                    {
                        Console.WriteLine(myList.Move());
                    }
                    else if (input[0] == "Print")
                    {
                        myList.Print();


                    }
                    else if (input[0] == "HasNext")
                    {
                        Console.WriteLine(myList.HasNext());

                    }
                    else if (input[0] == "PrintAll")
                    {
                        Console.WriteLine(string.Join(" ",myList));
                    }

                }
                catch (InvalidOperationException e )
                {

                    Console.WriteLine(e.Message);

                }
                input = Console.ReadLine().Split();


            }
        }

    }
}