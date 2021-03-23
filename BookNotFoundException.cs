using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagement.CustomExceptions
{
    public class BookNotFoundException:Exception
    {
        public BookNotFoundException(string Message) : base(Message)
        {

        }

        public BookNotFoundException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
