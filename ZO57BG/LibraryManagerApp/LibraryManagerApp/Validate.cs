using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerApp
{
    public static class Validate
    {
        public static string GetValidInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if(string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("A bemenet nem lehet ures. Probald meg megegyszer");
                }
            }while(string.IsNullOrEmpty(input));

            return input;
        }

        public static int GetValidYear(string prompt)
        {
            int year;
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!int.TryParse(input, out year) || year <= 0)
                {
                    Console.WriteLine("Egy ervenyes pozitiv evet adj meg");
                    year = 0;
                }
            } while (year <= 0);
            return year;
        }
    }
}
