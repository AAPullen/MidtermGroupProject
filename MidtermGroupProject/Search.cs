using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermGroupProject
{
    public class Search
    {

        public static List<Book> SearchByAuthor(List<Book> Book, string author) 
        {
            List<Book> matchingBooks = new List<Book>();
            foreach (Book book in Book)
            {
                if (book.Author == author)
                {
                    matchingBooks.Add(book);
                }
            }
            return matchingBooks; 
        }
        public static List<Book> SearchByTitle(List<Book> Book, string keyword) 
        {
            List<Book> matchingBooks = new List<Book>();
            foreach (Book book in Book)
            {
                if (book.Title.ToLower().Contains(keyword.ToLower()))
                {
                    matchingBooks.Add(book);
                }
            }
            return matchingBooks;
        }
    }
}
