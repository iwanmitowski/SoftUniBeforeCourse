using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int wreaths = 0;
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int lili = lilies.Peek();
            int rose = roses.Peek();
            int sum = 0;

            int leftedFlowers = 0;
            while (lilies.Count != 0 || roses.Count != 0)
            {

                sum = lili + rose;


                if (sum == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                    if (lilies.Count == 0 || roses.Count == 0)
                    {
                        break;
                    }
                    lili = lilies.Peek();
                    rose = roses.Peek();
                    sum = lili + rose;
                }
                else if (sum > 15)
                {
                    lili -= 2;
                    
                }
                else if (sum < 15)
                {
                    lilies.Pop();
                    roses.Dequeue();

                    leftedFlowers += sum;

                    if (lilies.Count == 0 || roses.Count == 0)
                    {
                        break;
                    }

                    lili = lilies.Peek();
                    rose = roses.Peek();

                }


                

            }

            wreaths += leftedFlowers / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
