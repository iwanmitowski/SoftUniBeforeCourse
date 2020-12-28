using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favBook = Console.ReadLine();
            int booksChecked = 0;
            bool isFound = false;

            while (true)
            {
                string currentBook = Console.ReadLine();
                
                if (currentBook=="No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {booksChecked} books.");
                    break;
                }
                else if (currentBook==favBook)
                {
                    isFound = true;
                    Console.WriteLine($"You checked {booksChecked} books and found it.");
                    break;
                }
                booksChecked++;
            }
        }
    }
}
