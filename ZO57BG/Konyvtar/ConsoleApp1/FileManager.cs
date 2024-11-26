using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    internal class FileManager
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
                    throw new FileNotFoundException("Nem talalhato a JSON fajl!");
                }

                string jsonContent = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Book>>(jsonContent) ?? new List<Book>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
                return new List<Book>();
            }
            catch (Exception ex) {
                Console.WriteLine($"Hiba: {ex.Message}");
                return new List<Book>();
            }
        }
    }
}
