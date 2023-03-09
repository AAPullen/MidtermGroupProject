using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MidtermGroupProject.BookStatus;

namespace MidtermGroupProject
{
    public class Book
    {
        public string Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DueDate { get; set; }
        public BookStatuses Status { get; set; }
        


        public Book(string _Id, string _Title, string _Author, DateTime _DueDate, BookStatuses _Status)
        {
            Id = _Id;
            Title = _Title;
            Author = _Author;
            DueDate = _DueDate;
            Status = _Status;
        }



    }
}
