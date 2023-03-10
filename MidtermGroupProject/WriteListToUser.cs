using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermGroupProject
{
    public class WriteListToUser
    {
       public void WriteListToConsole(List<Book> Book) 
        {
            foreach (var book in Book)
            {
              Console.WriteLine($"{book.Id}:  {book.Title} by {book.Author}\n");

            }
        }
    }
}
