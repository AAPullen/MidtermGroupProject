using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermGroupProject
{
    public class CheckoutReturn
    {
        //Create methods to handle changes to book Status/DueDate according to action taken by user
        public static void CheckOut(Book book)
        {
            book.Status = BookStatus.BookStatuses.CheckedOut;
            book.DueDate = DateTime.Now.AddDays(14);
        }

        public static void Return(Book book)
        {
            book.Status = BookStatus.BookStatuses.OnShelf;
            book.DueDate = DateTime.Now;
        }

        public static void Reserve(Book book)
        {
            book.Status = BookStatus.BookStatuses.Reserved;
            book.DueDate = DateTime.Now.AddDays(7);
        }
    }
}
