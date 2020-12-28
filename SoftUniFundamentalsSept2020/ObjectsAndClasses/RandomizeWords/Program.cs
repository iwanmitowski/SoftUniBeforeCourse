using System;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            for (int i = 0; i < arr.Length; i++)
            {
                Random rnd = new Random();

                int index = rnd.Next(0, arr.Length);
                string word = arr[i];
                arr[i] = arr[index];
                arr[index] = word;
            }
            Console.WriteLine(string.Join(Environment.NewLine,arr));
        }
    }
}
