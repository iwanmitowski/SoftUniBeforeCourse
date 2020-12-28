
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string title = input[0];
                string content = input[1];
                string author = input[2];
                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            string criteria = Console.ReadLine();
            if (criteria=="title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (criteria=="content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (criteria=="author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

          

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
}
