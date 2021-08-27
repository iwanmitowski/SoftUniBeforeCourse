using System;
using System.Linq;
using System.Text;
using BookShop.Data;
using System.Globalization;
using BookShop.Models.Enums;
using BookShop.Initializer;

namespace BookShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new BookShopContext();

            using (db)
            {
                //DbInitializer.ResetDatabase(db);

                //P02
                //var command = Console.ReadLine().ToLower();
                //Console.WriteLine(GetBooksByAgeRestriction(db, command));

                //P3
                //Console.WriteLine(GetGoldenBooks(db));

                //P4
                //Console.WriteLine(GetBooksByPrice(db));

                //P5
                //var year = int.Parse(Console.ReadLine());
                //Console.WriteLine(GetBooksNotReleasedIn(db, year));

                //P6
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBooksByCategory(db, input));

                //P7
                //var date = Console.ReadLine();
                //Console.WriteLine(GetBooksReleasedBefore(db, date));

                //P8
                //var input = Console.ReadLine();
                //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

                //P9
                //var input = Console.ReadLine().ToLower();
                //Console.WriteLine(GetBookTitlesContaining(db, input));

                //P10
                //var input = Console.ReadLine().ToLower();
                //Console.WriteLine(GetBooksByAuthor(db, input));

                //P11
                //var input = int.Parse(Console.ReadLine());
                //Console.WriteLine(CountBooks(db, input));

                //P12
                //Console.WriteLine(CountCopiesByAuthor(db));

                //P13
                //Console.WriteLine(GetTotalProfitByCategory(db));

                //P14
                //Console.WriteLine(GetMostRecentBooks(db));

                //P15
                //IncreasePrices(db);

                //P16
                //Console.WriteLine(RemoveBooks(db));
            }
        }

        //P16 - Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            //Query which books should be removed
            //Not used .ToList() because the actual books are not needed
            var books = context.Books
                .Where(x => x.Copies < 4200);

            var count = books.Count();

            var bookCategories = context.BookCategories
                .Where(x => x.Book.Copies < 4200);

            context.RemoveRange(bookCategories);
            context.RemoveRange(books);
            context.SaveChanges();

            return count;
        }

        //P15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //P14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks
                    .Select(x => x.Book)
                    .OrderByDescending(x => x.ReleaseDate).Take(3),
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        //P13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            //DbSet -> Mapping table -> Aggregating function
            var categories = context
                .Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Profit = x.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return sb.ToString().Trim();
        }

        //P12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    BooksCount = x.Books.Sum(b => b.Copies),
                })
                .OrderByDescending(x => x.BooksCount)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.BooksCount}");
            }

            return sb.ToString().Trim();
        }

        //P11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        //P10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Where(x => x.LastName.ToLower().StartsWith(input)).ToList();

            var books = context.Books
                .Where(x => authors.Contains(x.Author))
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    FullName = x.Author.FirstName + " " + x.Author.LastName,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FullName})");
            }

            return sb.ToString().Trim();
        }

        //P9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //P8 
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + " " + x.LastName)
                .OrderBy(x => x)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().Trim();
        }

        //P7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.ReleaseDate < DateTime.Parse(date))
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.ReleaseDate,
                    x.Price,
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        //P6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var categories = input
                .Split()
                .Select(x => x.ToLower());

            //Getting books by list of categories

            var books = context.Books
                .Where(b => b.BookCategories
                        .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //P5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    x.BookId,
                    x.Title
                })
                .OrderBy(x => x.BookId);

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        //P4
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            const decimal Price = 40;

            var books = context.Books
                .Where(x => x.Price > Price)
                .Select(x => new { x.Title, x.Price })
                .OrderByDescending(x => x.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        //P3
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .Select(x => new
                {
                    x.BookId,
                    x.Title
                })
                .OrderBy(x => x.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        //P2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }
    }
}
