using System;

namespace BookStoreManagement.CustomExceptions
{
    public class InvalidBookIdException : Exception
    {
        public InvalidBookIdException(string Message) : base(Message)
        {

        }
        public InvalidBookIdException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
