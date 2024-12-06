using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LibraryManagerApp
{
    public class FileManager
    {
        private readonly string _filePath;

        public FileManager(string filePath)
        {
            _filePath = filePath;
        }

        public List<Book> LoadBooks()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    throw new FileNotFoundException("Nem talalhato a JSON fajl");
                }

                string jsonContent = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Book>>(jsonContent) ?? new List<Book>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON data: {ex.Message}");
                return new List<Book>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return new List<Book>();
            }
        }

        public void SaveBooks(List<Book> books)
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, jsonContent);
                Console.WriteLine("Konyvek sieresen mentve");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba tortent a konyvek mentesekor: {ex.Message}");
            }
        }
    }
}
