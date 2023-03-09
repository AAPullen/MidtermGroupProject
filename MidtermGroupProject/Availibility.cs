using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermGroupProject
{
    public class Availibility
    {
        public static bool CheckAvailability(Book book)
        {
            if (book.Status == BookStatus.BookStatuses.OnShelf)
            {
                return true;
            }
            return false;
        }
    }
}
