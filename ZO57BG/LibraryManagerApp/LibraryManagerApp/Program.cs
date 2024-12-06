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

                    string choice = Validate.GetValidInput("Valassz egy opciot: ");

                    switch (choice)
                    {
                        case "1":
                            libraryManager.DisplayAllBooks();
                            break;
                        case "2":
                            string genre = Validate.GetValidInput("Adj meg egy mufajt: ");
                            libraryManager.DisplayFilteredBooks(genre);
                            break;
                        case "3":
                            libraryManager.DisplayBooksGroupedByGenre();
                            break;
                        case "4":
                            string author = Validate.GetValidInput("Adj meg egy szerzot: ");
                            libraryManager.SearchBooksByAuthor(author);
                            break;
                        case "5":
                            string title = Validate.GetValidInput("Konyv cime: ");
                            string newAuthor = Validate.GetValidInput("Konyv szerzoje: ");
                            int year = Validate.GetValidYear("Konyv kiadasi eve: ");
                            string newGenre = Validate.GetValidInput("Konyv mufaja: ");

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
