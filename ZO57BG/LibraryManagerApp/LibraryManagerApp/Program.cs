using System;

using LibraryManagerApp;

namespace LibraryManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "books.json");

            try
            {
                var fileManager = new FileManager(filePath);
                var books = fileManager.LoadBooks();

                var libraryManager = new LibraryManager(books, filePath);

                while (true)
                {
                    Console.WriteLine("\nLibrary Management Menu:");
                    Console.WriteLine("1. Osszes konyv");
                    Console.WriteLine("2. Szures mufaj szerint");
                    Console.WriteLine("3. Mufaj szerinti rendezes");
                    Console.WriteLine("4. Kereses szerzo szerint");
                    Console.WriteLine("5. Konyv hozzaadasa");
                    Console.WriteLine("6. Legujabb es legregebbi konyv");
                    Console.WriteLine("7. Kilepes");

                    Console.Write("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            libraryManager.DisplayAllBooks();
                            break;
                        case "2":
                            Console.Write("Enter a genre to filter: ");
                            string genre = Console.ReadLine();
                            libraryManager.DisplayFilteredBooks(genre);
                            break;
                        case "3":
                            libraryManager.DisplayBooksGroupedByGenre();
                            break;
                        case "4":
                            Console.Write("Enter an author to search: ");
                            string author = Console.ReadLine();
                            libraryManager.SearchBooksByAuthor(author);
                            break;
                        case "5":
                            Console.Write("Enter book title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter author: ");
                            string newAuthor = Console.ReadLine();
                            Console.Write("Enter publication year: ");
                            int year = int.Parse(Console.ReadLine());
                            Console.Write("Enter genre: ");
                            string newGenre = Console.ReadLine();

                            libraryManager.AddBook(new Book(title, newAuthor, year, newGenre));
                            break;
                        case "6":
                            libraryManager.DisplayAggregatedData();
                            break;
                        case "7":
                            Console.WriteLine("Exiting program. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
