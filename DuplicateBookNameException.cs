using System;

namespace BookStoreManagement.CustomExceptions
{
    public class DuplicateBookNameException : Exception
    {
        public DuplicateBookNameException(string Message) : base(Message)
        {

        }
        public DuplicateBookNameException(string Message,Exception innerException) : base(Message, innerException)
        {

        }
    }
}
