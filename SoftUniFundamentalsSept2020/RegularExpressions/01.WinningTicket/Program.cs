using System;
using System.Text.RegularExpressions;

namespace _01.WinningTicket
{

    class Program
    {
        public static string longestSymbSeq = "";
        static void Main(string[] args)
        {
            string pattern = @"^.*([@]{6,10}|[#]{6,10}|[$]{6,10}|[\^]{6,10}).*\1.*$";
            Regex regex = new Regex(pattern);

            string[] tickets = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in tickets)
            {
                Match match = regex.Match(ticket);
                if (ticket.Length == 20)
                {
                    if (match.Success)
                    {
                        string left = match.ToString().Substring(0, 10);
                        string right = match.ToString().Substring(10);



                        int leftSymbols = CountingSymbols(left);
                        int rightSymbols = CountingSymbols(right);

                        int bestSequence = Math.Min(leftSymbols, rightSymbols);


                        if (bestSequence == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - 10{ticket[1]} Jackpot!");
                        }
                        else if (leftSymbols == 10 && rightSymbols >= 6)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {rightSymbols}{longestSymbSeq}");
                        }
                        else if (leftSymbols >= 6 && rightSymbols == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {leftSymbols}{longestSymbSeq}");
                        }
                        else if (leftSymbols < 6 && rightSymbols >= 6)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                        else if (leftSymbols >= 6 && rightSymbols < 6)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                        else if (leftSymbols==rightSymbols)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {leftSymbols}{longestSymbSeq}");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {leftSymbols}{longestSymbSeq}");
                        }
                       



                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }

        public static int CountingSymbols(string leftOrRight)
        {
            int similarSymbol = 1;
            int bestSimilarSymbol = 1;

            for (int i = 0; i < leftOrRight.Length-1; i++)
            {
                if (leftOrRight[i+1] == leftOrRight[i])
                {
                    similarSymbol++;
                    if (similarSymbol > bestSimilarSymbol)
                    {
                        bestSimilarSymbol = similarSymbol;
                    }
                    longestSymbSeq = leftOrRight[i].ToString();
                }
                else
                {
                    similarSymbol = 1;

                }
            }
            
            return bestSimilarSymbol;
        }
    }
}
