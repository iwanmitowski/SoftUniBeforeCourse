﻿using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split();
            string[] secondArr = Console.ReadLine().Split();
            string result = string.Empty;

            for (int i = 0; i <secondArr.Length; i++)
            {

                for (int j = 0; j < firstArr.Length; j++)
                {

                    if (secondArr[i] == firstArr[j])
                    {
                        

                        Console.Write(secondArr[i]+ " ");
                    }
                }
                
            }
        }
    }
}
