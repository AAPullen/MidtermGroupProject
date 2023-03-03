using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermGroupProject
{
    public class CheckoutReturn
    {
        public void CheckOut(Book book)
        {
            book.Status = BookStatus.CheckedOut;
            book.DueDate = DateTime.Now.AddDays(14);
        }

        public void Return(Book book)
        {
            book.Status = BookStatus.OnShelf;
            book.DueDate = DateTime.Now;
        }

        public void Reserve(Book book)
        {
            book.Status = BookStatus.Reserved;
            book.DueDate = DateTime.Now.AddDays(7);
        }
    }
}
