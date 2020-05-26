using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Library
{

    class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;
        //Constructor
        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
            
        }
        // Implementing GetEnumerator Method of IEnumerable Interface
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        //Internal class called LibraryIterator For holding different lists
        class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;
            //Constructor of LibraryIterator
            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
           // Implementation of methods of IEnumerator Interface
            public void Dispose()
            {

            }
            public bool MoveNext() => ++this.currentIndex < this.books.Count;
            public void Reset() => this.currentIndex = -1;
            public Book Current => this.books[this.currentIndex];
            object IEnumerator.Current => this.Current;
        }

    }
}
