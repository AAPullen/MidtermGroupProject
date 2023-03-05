using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace MidtermGroupProject
{
    internal class Search
    {
        private List<Book> books;

        public Search(List<Book> books)
        {
            this.books = books;
        }

        public void SearchByAuthor(string author) // I have this as a void for now since its returning text to the console. maybe this should return a list?
        {
            List<Book> matchingBooks = new List<Book>();
            foreach (Book book in books)
            {
                if (book.author == author) // need to fix this to work with the books class. still tbd
                {
                    matchingBooks.Add(book);
                }
            }
            if (matchingBooks.Count == 0)
            {
                Console.WriteLine("Sorry but we have no books in the library collection by " + author);
            }
            else
            {
                Console.WriteLine("We have the following book(s) in our library collection by: ", author);
                foreach (Book book in matchingBooks)
                {
                    Console.WriteLine(book.title); // need to fix this to work with the books class. still tbd
                }
            }
        }
        public void SearchByTitle(string keyword) // I have this as a void for now since its returning text to the console. maybe this should return a list?
        {
            List<Book> matchingBooks = new List<Book>();
            foreach (Book book in books)
            {
                if (book.title.ToLower().Contains(keyword.ToLower())) // need to fix this to work with the books class. still tbd
                {
                    matchingBooks.Add(book);
                }
            }
            if (matchingBooks.Count == 0)
            {
                Console.WriteLine("No books with '{0}' in the title found in the library.", keyword);
            }
            else
            {
                Console.WriteLine("Books with '{0}' in the title:", keyword);
                foreach (Book book in matchingBooks)
                {
                    Console.WriteLine("{0} by {1}", book.title, book.author); // need to fix this to work with the books class. still tbd
                }
            }
        }
    }
}
