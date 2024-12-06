﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerApp
{
    public class LibraryManager
    {
        private readonly List<Book> _books;

        public LibraryManager(List<Book> books)
        {
            _books = books;
        }

        public void AddBook(string title, string author, int year, string genre) { 
            _books.Add(new Book(title, author, year, genre));
            Console.WriteLine("Konyv sikeresen hozzaadva");
        }

        public void DisplayFilteredBooks(string genre)
        {
            var filteredBooks = _books
                .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                .OrderBy(b => b.Year)
                .ToList();

            Console.WriteLine("\nSzurt es rendezett konyvek:");
            foreach(var book in filteredBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author} ({book.Year}) - Genre: {book.Genre}");
            }
        }

        public void DisplayAggregatedData()
        {
            var oldestBook = _books.Min(b => b.Year);
            var newestBook = _books.Max(b => b.Year);

            Console.WriteLine($"\nLegkorabban kiadott konyv: {oldestBook}");
            Console.WriteLine($"Legujabban kiadott konyv: {newestBook}");
        }

        public void DisplayBooksGroupedByGenre()
        {
            var groupedBooks = _books.GroupBy(b => b.Genre);

            Console.WriteLine("\nMufaj szerint csoportositott konyvek:");
            foreach(var group in groupedBooks)
            {
                Console.WriteLine($"\nGenre: {group.Key}");
                foreach(var book in group)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author} ({book.Year})");
                }
            }
        }
    }
}
