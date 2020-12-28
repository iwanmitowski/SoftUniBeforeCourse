using System;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleThings = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());
            
            string title = articleThings[0];
            string content = articleThings[1];
            string author = articleThings[2];

            Article article = new Article(title, content, author);

            for (int i = 0; i < n; i++)
            {

                string[] command = Console.ReadLine().Split(": ");
                string action = command[0];
                string thingToChange = command[1];

                if (action == "Edit")
                {
                    article.Edit(thingToChange);
                }
                else if (action == "ChangeAuthor")
                {
                    article.ChangeAuthor(thingToChange);
                }
                else if (action == "Rename")
                {
                    article.Rename(thingToChange);
                }
            }
            Console.WriteLine(article);
        }
    }
}
