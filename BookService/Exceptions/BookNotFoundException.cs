using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookService.Exceptions
{
    public class BookNotFoundException : Exception
    {
        private const string BookNotFoundMessage = "No book found for ID {0}";

        public BookNotFoundException(int bookId)
            : base(String.Format(BookNotFoundMessage, bookId))
        {
        }
    }
}