using System;

namespace _04.Generating01Vectors
{
    class Program
    {
        static void Generate(int[] vector,int index)
        {
            if (index>vector.Length-1)
            {
                Console.WriteLine(string.Join("",vector));
                return;
            }

            for (int i = 0; i <=1 ; i++)
            {
                vector[index] = i;
                Generate(vector, index + 1);
            }

        }
        static void Main(string[] args)
        {
            int index = int.Parse(Console.ReadLine());
            Generate(new int[index], 0);
        }
    }
}
