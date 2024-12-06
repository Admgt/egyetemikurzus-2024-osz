using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerApp
{
    public class LibraryManager
    {
        private readonly List<Book> _books;

        private readonly FileManager fileManager;

        public LibraryManager(List<Book> books, string filePath)
        {
            _books = books;
            fileManager = new FileManager(filePath);
        }

        public void AddBook(Book book) {
            try
            {
                var books = fileManager.LoadBooks();
                books.Add(book);
                fileManager.SaveBooks(books);
                Console.WriteLine("Book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
            }
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

        public void SearchBooksByAuthor(string author)
        {
            var matchingBooks = _books
                .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine("\nKonyvek szerzoktol:");
            if(matchingBooks.Any())
            {
                foreach(var book in matchingBooks)
                {
                    Console.WriteLine($"{book.Title} by {book.Author} ({book.Year}) - Genre: {book.Genre}");
                }
            }
            else
            {
                Console.WriteLine("Nincs konyv az adott szerzotol");
            }
        }

        public void DisplayAllBooks()
        {
            try
            {
                var books = fileManager.LoadBooks();
                if(books.Count == 0)
                {
                    Console.WriteLine("Nem talalhato konyv");
                }
                else
                {
                    Console.WriteLine("Az osszes konyv:");
                    foreach(var book in books)
                    {
                        Console.WriteLine($"- {book.Title} by {book.Author} ({book.Year}) - Genre: {book.Genre}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Valami hiba tortent: {ex.Message}");
            }
        }

        public List<Book> GetBooks()
        {
            return _books;
        }
    }
}
