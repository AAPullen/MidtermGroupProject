using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermGroupProject
{
    internal class Search
    {

        public void SearchByAuthor(List<Book> Book,  string author) // I have this as a void for now since its returning text to the console. maybe this should return a list?
        {
            List<Book> matchingBooks = new List<Book>();
            foreach (Book book in Book)
            {
                if (book.Author == author) 
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
                Console.WriteLine("We have the following book(s) in our library collection by: " +  author);
                foreach (Book book in matchingBooks)
                {
                    Console.WriteLine(book.Title);
                }
            }
        }
        public void SearchByTitle(List<Book> Book, string keyword) // I have this as a void for now since its returning text to the console. maybe this should return a list?
        {
            List<Book> matchingBooks = new List<Book>();
            foreach (Book book in Book)
            {
                if (book.Title.ToLower().Contains(keyword.ToLower())) 
                {
                    matchingBooks.Add(book);
                }
            }
            if (matchingBooks.Count == 0)
            {
                Console.WriteLine("No books found in the library with the title of" + keyword);
            }
            else
            {
                Console.WriteLine("We have the following books: ");
                foreach (Book book in matchingBooks)
                {
                    Console.WriteLine(book.Title, book.Author); 
                }
            }
        }
    }
}
