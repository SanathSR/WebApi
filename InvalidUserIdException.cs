using System;

namespace BookStoreManagement.CustomExceptions
{
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException(string Message) : base(Message)
        {

        }
        public InvalidUserIdException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
