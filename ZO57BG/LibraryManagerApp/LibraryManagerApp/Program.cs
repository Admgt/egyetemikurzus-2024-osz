using System;
using System.IO;

using LibraryManagerApp;

namespace LibraryManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "books.json";

            try
            {
                var fileManager = new FileManager(filePath);
                var books = fileManager.LoadBooks();

                var libraryManager = new LibraryManager(books);

                Console.WriteLine("Enter a genre to filter by (e.g., Fiction, Science): ");
                string genre = Console.ReadLine();
                libraryManager.DisplayFilteredBooks(genre);

                libraryManager.DisplayAggregatedData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

