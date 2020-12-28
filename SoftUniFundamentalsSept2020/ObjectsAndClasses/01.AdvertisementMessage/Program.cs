using System;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product" };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Random rnd = new Random();

                string phrase = phrases[rnd.Next(0, 5)];
                string eventt = events[rnd.Next(0, 5)];
                string author = authors[rnd.Next(0, 5)];
                string city = cities[rnd.Next(0, 5)];

                Console.WriteLine($"{phrase} {eventt} {author} – {city}.");
            }
        }
    }
    
}
