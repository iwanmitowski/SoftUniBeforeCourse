using System;
using System.Collections.Generic;
using System.Linq;

namespace MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < Math.Min(firstList.Count, secondList.Count); i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[secondList.Count - 1 - i]);

            }

            int secondLastNum = 0;
            int LastNum = 0;


            if (firstList.Count > secondList.Count)
            {
                secondLastNum = firstList[firstList.Count - 2];
                LastNum = firstList[firstList.Count - 1];
            }
            else if (firstList.Count < secondList.Count)
            {
                //0 и 1 са последните 2, защото е отзад напред! (Понеже не го reverse-вам)
                secondLastNum = secondList[0];
                LastNum = secondList[1];
            }

            int smallerNum = Math.Min(secondLastNum, LastNum);
            int biggerNum = Math.Max(secondLastNum, LastNum);

            result.Sort();

            Console.WriteLine(string.Join(" ", result.Where(x => x > smallerNum && x < biggerNum)));
        }
    }
}
