using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerApp
{
    public record Book(string Title, string Author, int Year, string Genre);
}
