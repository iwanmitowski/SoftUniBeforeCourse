using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http.Headers;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            int sumVowels = 0;
            int sumConsonant = 0;
            int sum = 0;

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                
                
                foreach (char letter in name)
                {
                    
                    switch (letter)
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            sumVowels += (int)letter * name.Length;
                           

                            break;



                        default:
                            sumConsonant += (int)letter / name.Length;
                            
                            break;
                    }
                   


                }
                sum = sumVowels + sumConsonant;
                arr[i] = sum;
                sumVowels = 0;
                sumConsonant = 0;
                sum = 0;
               
                

            }
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
