using System;

namespace BookStoreManagement.CustomExceptions
{
    public class InvalidAvilableForException :Exception
    {
        public InvalidAvilableForException(string Message) : base(Message)
        {

        }

        public InvalidAvilableForException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
