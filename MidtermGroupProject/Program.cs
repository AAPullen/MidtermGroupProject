

using MidtermGroupProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Numerics;


// book list class so I can create a list of the 12 books  --> Extra credit will go to storing it eventually in a text file and reading it from there // writing to it?


List<Book> BookList = new List<Book>();

if (File.Exists(@"C:\Users\billy\BookList.txt"))
{
    
    
        using (StreamReader reader = new StreamReader(@"C:\Users\billy\BookList.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
            string[] split = line.Split("||");
            Book BookFromFile = new Book(split[0], split[1], split[2], DateTime.Parse(split[3]), Enum.Parse<BookStatus.BookStatuses>(split[4]));
            BookList.Add(BookFromFile);
            }
        }
}
else
{
    BookList.Add(new Book("ID: 001", "IT STARTS WITH US", "Colleen Hoover", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 002", "LESSONS IN CHEMISTRY", "Bonnie Garmus", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 003", "BURNER", "Mark Greaney", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 004", "SPARE", "Prince Harry", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 005", "THE LIGHT WE CARRY", "Michelle Obama", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 006", "TOMORROW, AND TOMORROW, AND TOMORROW", "Gabrielle Zevin", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 007", "I HAVE SOME QUESTIONS FOR YOU", "Rebecca Makkai", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 008", "SOMEONE ELSE'S SHOES", "Jojo Moyes", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 009", "IT ENDS WITH US", "Colleen Hoover", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 010", "HEART BONES", "Colleen Hoover", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 011", "ALL ABOUT LOVE", "Bell Hooks", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 012", "BRAIDING SWEETGRASS", "Robin Wall Kimmerer", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 013", "LIBRARY OF ALEXANDRIA", "Julius Caesar", DateTime.Now, BookStatus.BookStatuses.OnShelf));
    BookList.Add(new Book("ID: 014", "CASTE", "Isabel Wilkerson", DateTime.Now, BookStatus.BookStatuses.OnShelf));
}


//These books are checked out for demo purposes
CheckoutReturn.CheckOut(BookList[0]);
CheckoutReturn.CheckOut(BookList[1]);

Console.WriteLine("Hello and welcome to McWhitLen Library\n");
var userInput = "";


while (true)
{
    do
    {
        Console.WriteLine("Please enter the number of the option you would like to select: \n(1) Search for a book to checkout \n(2) Return a book \n(3) See a list of all books \n(4) To exit");
        userInput = Console.ReadLine();
        if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4")
        {
            Console.WriteLine("\nThat is not a valid option.\n");
        }
    } while (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4");

    if (userInput == "1")
    {
        do
        {
            Console.WriteLine("\nPlease enter the number of the option you would like to select: \n(1) To Search By Title \n(2) To Search By Author \n(3) To Pick From a List ");
            userInput = Console.ReadLine();
            if (userInput != "1" && userInput != "2" && userInput != "3")
            {
                Console.WriteLine($"\nThat is not a valid option.");
            }
        } while (userInput != "1" && userInput != "2" && userInput != "3");

 
        if (userInput == "1")
        {
            string titleChosen;
            Console.Write($"\nPlease enter the Title you would like to search: ");
            titleChosen = Console.ReadLine();

            if (titleChosen == "LIBRARY OF ALEXANDRIA")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                ShowSimplePercentage();
                Console.WriteLine("\n\n!!!!!!!!! \n\n OH NO! \n\n\n YOU JUST BURNED DOWN THE LIBRARY OF ALEXANDRIA!!!!!!! \n\n\nHOW DARE THEE!!!!!!!!");
                break;
            }

            List<Book> matchingBook = Search.SearchByTitle(BookList, titleChosen);
            WriteListToUser.WriteListToConsole(matchingBook);

            if (matchingBook.Count > 0)
            {
                Console.Write($"\nPlease choose a book by entering the Id number here: ");
                string IdChosen = Console.ReadLine();
                int BookToUpdate = -1;

                bool isValidId = false;
                do
                {
                    try
                    {
                        BookToUpdate = int.Parse(IdChosen) - 1;
                        if (BookToUpdate > -1 && BookToUpdate < BookList.Count)
                        {
                            isValidId = true;
                        }
                        else
                        {
                            Console.WriteLine("\nThat is not a valid choice. Please enter a book Id from the list below.");
                            WriteListToUser.WriteListToConsole(matchingBook);
                            IdChosen = Console.ReadLine();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nThat is not a valid choice. Please enter a book Id from the list below.");
                        WriteListToUser.WriteListToConsole(matchingBook);
                        IdChosen = Console.ReadLine();
                    } 
                } while (isValidId == false);

                if (BookList[BookToUpdate].Status == BookStatus.BookStatuses.OnShelf)
                {
                    Book BookChosen = BookList[BookToUpdate];
                    CheckoutReturn.CheckOut(BookChosen);
                    Console.WriteLine($"\nYou checked out {BookList[BookToUpdate].Title} by {BookList[BookToUpdate].Author}. The due date is {BookList[BookToUpdate].DueDate} \n");
                }
                else
                {
                    Console.WriteLine($"\nI'm Sorry, that book {BookList[BookToUpdate].Title} is currently checked out. It will be available: {BookList[BookToUpdate].DueDate} \n");
                }
            }
            else Console.WriteLine("\nThere are no books available by that title");
        }


        else if (userInput == "2")
        {
            string authorChosen;
            Console.Write("\nPlease enter the name of the author you would like to search: ");
            authorChosen = Console.ReadLine();


            List<Book> matchingAuthor = Search.SearchByAuthor(BookList, authorChosen);
            WriteListToUser.WriteListToConsole(matchingAuthor);

            if (matchingAuthor.Count > 0)
            {
                Console.Write("Please choose a book by entering the Id number here: \n");
                string IdChosen = Console.ReadLine();
                int BookToUpdate = - 1;

                bool isValidId = false;
                do
                {
                    try
                    {
                        BookToUpdate = int.Parse(IdChosen) - 1;
                        if(BookToUpdate > -1 && BookToUpdate < BookList.Count)
                        {
                            isValidId = true;
                        }
                        else
                        {
                            Console.WriteLine("\nThat is not a valid choice. Please enter a book Id from the list below.");
                            WriteListToUser.WriteListToConsole(matchingAuthor);
                            IdChosen = Console.ReadLine();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nThat is not a valid choice. Please enter a book Id from the list below.");
                        WriteListToUser.WriteListToConsole(matchingAuthor);
                        IdChosen = Console.ReadLine();
                    } 
                } while (isValidId == false);


                if (BookList[BookToUpdate].Status == BookStatus.BookStatuses.OnShelf)
                {
                    Book BookChosen = BookList[BookToUpdate];
                    CheckoutReturn.CheckOut(BookChosen);
                    Console.WriteLine($"You checked out {BookList[BookToUpdate].Title} by {BookList[BookToUpdate].Author}. The due date is {BookList[BookToUpdate].DueDate}");
                }
                else
                {
                    Console.WriteLine($"I'm Sorry, that book is currently checked out. It will be available: {BookList[BookToUpdate].DueDate}");
                }
            }
            else Console.WriteLine("There are no books available by that author");
        }
        else if (userInput == "3")
        {
            Console.WriteLine("\nPlease select the Id number of the book from the following list that you would like to checkout.");
            WriteListToUser.WriteListToConsole(BookList);

            Console.Write("\nPlease enter your selection: ");
            string IdChosen = Console.ReadLine();
            int BookToUpdate = -1;
            
            bool isValidId = false;
            do
            {
                try
                {
                    BookToUpdate = int.Parse(IdChosen) - 1;
                    if (BookToUpdate > -1 && BookToUpdate < BookList.Count) 
                    {
                        isValidId = true;
                    }
                    else
                    {
                        Console.WriteLine("\nThat is not a valid choice. Please enter a book Id from the list below.");
                        WriteListToUser.WriteListToConsole(BookList);
                        IdChosen = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nThat is not a valid choice. Please enter a book Id from the list below.");
                    WriteListToUser.WriteListToConsole(BookList);
                    IdChosen = Console.ReadLine();
                } 
            } while (isValidId == false);

            

            if (BookList[BookToUpdate].Status == BookStatus.BookStatuses.OnShelf)
            {
                Book BookChosen = BookList[BookToUpdate];
                CheckoutReturn.CheckOut(BookChosen);
                Console.WriteLine($"You checked out {BookList[BookToUpdate].Title} by {BookList[BookToUpdate].Author}. The due date is {BookList[BookToUpdate].DueDate}");
            }
            else
            {
                Console.WriteLine($"I'm Sorry, that book is currently checked out. It will be available: {BookList[BookToUpdate].DueDate}");
            }
        }
    }
    else if (userInput == "2")
    {
        Console.WriteLine("\nPlease enter the ID of the book you want to return: ");

        List<Book> BooksCheckedOut = new List<Book>();

        foreach (var book in BookList)
        {
            if (book.Status == BookStatus.BookStatuses.CheckedOut)
            {

                Console.WriteLine($"{book.Id}:  {book.Title} by {book.Author} due date: {book.DueDate}");
            }
        }
        Console.Write("\nPlease enter your selection: ");
        string IdChosen = Console.ReadLine();
        int BookToUpdate = - 1;

        bool isValidId = false;

        do
        {
            try
            {
                BookToUpdate = int.Parse(IdChosen) - 1;
                if (BookToUpdate > -1 && BookToUpdate < BookList.Count)
                {
                    isValidId = true;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid choice. Please enter a book Id from the list below.");
                    foreach (var book in BookList)
                    {
                        if (book.Status == BookStatus.BookStatuses.CheckedOut)
                        {

                            Console.WriteLine($"{book.Id}:  {book.Title} by {book.Author} due date: {book.DueDate}");
                        }
                    }
                    IdChosen = Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nThat is not a valid choice. Please enter a book Id from the list below.");
                foreach (var book in BookList)
                {
                    if (book.Status == BookStatus.BookStatuses.CheckedOut)
                    {

                        Console.WriteLine($"{book.Id}:  {book.Title} by {book.Author} due date: {book.DueDate}");
                    }
                }
                IdChosen = Console.ReadLine();
            }
        } while (isValidId == false);

        if (BookList[BookToUpdate].Status == BookStatus.BookStatuses.CheckedOut)
        {
            Book BookChosen = BookList[BookToUpdate];
            CheckoutReturn.Return(BookChosen);
            Console.WriteLine($"\nYou returned {BookList[BookToUpdate].Title} by {BookList[BookToUpdate].Author}.");
        }
        else
        {
            Console.WriteLine("\nThat book is already on the shelf.");
        }
    }
    else if (userInput == "3")
    {
        foreach (var book in BookList)
        {
            Console.WriteLine($"{book.Id} {book.Title} by {book.Author}");
        }
    }
    else  //This is option 4 Exit
    {
        Console.WriteLine("\nThank you for visiting the McWhitLen Library. Goodbye!");
        break;
    }

    Console.WriteLine("\nPlease select another option.\n");



    static void ShowSimplePercentage()
    {
        for (int i = 0; i <= 100; i++)
        {
            Console.Write($"\rProgress: {i} %  ");
            Thread.Sleep(25);
        }
    }

    using (StreamWriter sw = File.CreateText(@"C:\Users\billy\BookList.txt"))

        foreach (var s in BookList)
        {
            sw.WriteLine(s.Id + "||" + s.Title + "||" + s.Author + "||" + s.DueDate + "||" + s.Status);
        }
}