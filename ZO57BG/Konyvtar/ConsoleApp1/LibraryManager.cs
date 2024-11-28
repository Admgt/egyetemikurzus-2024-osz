using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagerApp
{
    public class LibraryManager
    {
        private readonly List<Book> _books;

        public LibraryManager(List<Book> books)
        {
            _books = books;
        }

        public void DisplayFilteredBooks(string genre)
        {
            var filteredBooks = _books
                .where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                .OrderBy(b => b.Genre)
                .ToList();

            Console.WriteLine("\nFiltered and sorted books:");
            foreach (var book in filteredBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author} ({book.Year}) - Genre: {book.Genre}");
            }
        }

        public void DisplayAggregatedData()
        {
            var oldestBook = _books.Min(b => b.Year);
            var newestBook = _books.Max(b => b.Year);

            Console.WriteLine($"\nOldet book published in: {oldestBook}");
            Console.WriteLine($"Newest book published in: {newestBook}");
        }
    }
}