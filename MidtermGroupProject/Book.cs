using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermGroupProject
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DueDate { get; set; }
        //public enum Status { get; set; }  --> This is giving me an error for some reason and I need to try to figure out why
     
        
        public Book(string _Title, string _Author, DateTime _DueDate)
        {
            Title = _Title;
            Author = _Author;
            DueDate = _DueDate;
        }



    }
}
