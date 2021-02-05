using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.OrderBy(x=>x.Title).ThenByDescending(x=>x.Year).ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex = -1;
        private readonly List<Book> books;
        public LibraryIterator(List<Book> books)
        {
            this.books = books;
        }
        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.currentIndex++;
            if (currentIndex>=this.books.Count)
            {
                return false;
            }
            return true;
        }
        
        public void Reset()
        {
            this.currentIndex = -1;
        }
    }

}
