using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace CodensingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] condesed = new int[nums.Length - 1];

            

            

            if (nums.Length==1)
            {
                Console.WriteLine(nums[0]);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                
                for (int j = 0; j < condesed.Length-i; j++)
                {
                    condesed[j] = nums[j] +nums[j + 1];

                    
                }
                nums = condesed;
                

            }
            Console.WriteLine(condesed[0]);




        }
    }
    }
