using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bestSequence = 0;
            int bestIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int sequenceLength = 0;
                int currentIndex = 0;
                int curr = arr[i];
                for (int j = i ; j < arr.Length; j++)
                {
                    if (curr==arr[j])
                    {
                        sequenceLength++;
                        currentIndex = curr;
                        

                    }

                    else
                    {
                        break;
                    }
                    //bestseq проверка със sequencelengt
                    if (sequenceLength>bestSequence)
                    {
                        bestSequence = sequenceLength;
                        bestIndex = currentIndex;
                    }

                }

            }
            for (int i = 0; i < bestSequence; i++)
            {
                Console.Write(bestIndex+" ");

                
            }



        }
    }
}
