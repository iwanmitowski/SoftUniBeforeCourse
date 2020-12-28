using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            string[] command = Console.ReadLine().Split();

            while (command[0]!="End")
            {
                if (command[0]=="Add")
                {
                    nums.Add(int.Parse(command[1]));
                }
                else if (command[0]=="Insert")
                {
                    int index = int.Parse(command[2]);
                    int number = int.Parse(command[1]);
                    if (index<0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        nums.Insert(index, number);
                    }
                    
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index > nums.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        nums.RemoveAt(index);
                    }

                }
                else if (command[0] == "Shift")
                {
                    int repetition = int.Parse(command[2]);
                    if (command[1]== "left")
                    {
                        
                        
                        for (int i = 0; i < repetition; i++)
                        {
                            int firstNum = nums[0];
                            for (int j = 0; j < nums.Count-1; j++)
                            {
                                nums[j] = nums[j + 1];
                            }
                            nums[nums.Count-1] = firstNum;

                        }
                        
                    }
                    else if (command[1] == "right")
                    {
                        for (int i = 0; i < repetition; i++)
                        {
                            int lastNum = nums[nums.Count - 1];
                            for (int j = nums.Count - 1; j > 0; j--)
                            {
                                nums[j] = nums[j - 1];

                            }
                            nums[0] = lastNum;
                        }
                        
                    }
                }


                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
