using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagement.CustomExceptions
{
    public class BookNotAvailableForThatPurposeException : Exception
    {
        public BookNotAvailableForThatPurposeException(string Message) : base(Message)
        {

        }

        public BookNotAvailableForThatPurposeException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
