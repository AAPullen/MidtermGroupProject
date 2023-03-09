

using MidtermGroupProject;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;


// book list class so I can create a list of the 12 books  --> Extra credit will go to storing it eventually in a text file and reading it from there // writing to it?

List<Book> BookList = new List<Book>();


BookList.Add(new Book("1","IT STARTS WITH US", "Colleen Hoover", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("2", "LESSONS IN CHEMISTRY", "Bonnie Garmus", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("3", "BURNER", "Mark Greaney", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("4", "SPARE", "Prince Harry", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("5", "THE LIGHT WE CARRY", "Michelle Obama", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("6", "TOMORROW, AND TOMORROW, AND TOMORROW", "Gabrielle Zevin", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("7", "I HAVE SOME QUESTIONS FOR YOU", "Rebecca Makkai", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("8", "SOMEONE ELSE'S SHOES", "Jojo Moyes", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("9", "IT ENDS WITH US", "Colleen Hoover", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("10", "HEART BONES", "Colleen Hoover", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("11", "ALL ABOUT LOVE", "Bell Hooks", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("12", "BRAIDING SWEETGRASS", "Robin Wall Kimmerer", DateTime.Now, BookStatus.BookStatuses.OnShelf));
BookList.Add(new Book("13", "CASTE", "Isabel Wilkerson", DateTime.Now, BookStatus.BookStatuses.OnShelf));

Console.WriteLine("Hello and welcome to ____ Library");
var userInput = "";

do
{
    Console.WriteLine("Enter (1) Search for a book, (2) Return a book, or (3) To exit");
    userInput = Console.ReadLine();
    if (userInput != "1" && userInput != "2" && userInput != "3")
    {
        Console.WriteLine("That is not a valid option.");
    }
} while (userInput != "1" && userInput != "2" && userInput != "3");

if (userInput == "1")
{
    do
    {
        Console.WriteLine("Please select from the following: Enter (1) To Search By Title, Enter (2) To Search By Author, Or Enter (3) To Pick From a List");
        userInput = Console.ReadLine();
        if (userInput != "1" && userInput != "2" && userInput != "3")
        {
            Console.WriteLine("That is not a valid option.");
        }
    } while (userInput != "1" && userInput != "2" && userInput != "3");

    string titleChosen;
    if (userInput == "1")
    {
        Console.WriteLine("Please enter the Title you would like to search: ");
        titleChosen = Console.ReadLine();


        List<Book> matchingBook = Search.SearchByTitle(BookList, titleChosen);
        foreach (var bookreturned in matchingBook)
        {
            Console.WriteLine($"{bookreturned.Id}:  {bookreturned.Title} by {bookreturned.Author}");
        }

        if (matchingBook.Count > 0)
        {
            Console.WriteLine("Please choose a book by entering the Id number here: ");
            string IdChosen = Console.ReadLine();

            if (matchingBook.Any(book => book.Id == IdChosen && book.Status == BookStatus.BookStatuses.OnShelf))
            {
                string BookToUpdate = IdChosen;
                Book BookChosen = BookList[(int.Parse(BookToUpdate)) - 1];
                CheckoutReturn.CheckOut(BookChosen);
                Console.WriteLine(BookChosen.Status);
            }
        }
        else Console.WriteLine("There are no books availble by that title");
    }


    else if (userInput == "2")
    {
        string authorChosen;
        Console.WriteLine("Please enter the name of the author you would like to search: ");
        authorChosen = Console.ReadLine();


        List<Book> matchingAuthor = Search.SearchByAuthor(BookList, authorChosen);
        foreach (var bookreturned in matchingAuthor)
        {
            Console.WriteLine($"{bookreturned.Id}:  {bookreturned.Title} by {bookreturned.Author}");
        }

        if (matchingAuthor.Count > 0)
        {
            Console.WriteLine("Please choose a book by entering the Id number here: ");
            string IdChosen = Console.ReadLine();

            if (matchingAuthor.Any(book => book.Id == IdChosen && book.Status == BookStatus.BookStatuses.OnShelf))
            {
                string BookToUpdate = IdChosen;
                Book BookChosen = BookList[(int.Parse(BookToUpdate)) - 1];
                CheckoutReturn.CheckOut(BookChosen);
                Console.WriteLine(BookChosen.Status);
            }
        }
        else Console.WriteLine("There are no books availble by that author");
    }
     else if (userInput == "3")
    {
        Console.WriteLine("test");
        foreach (var book in BookList)
        {
            Console.WriteLine(book);
        }
    }
}

