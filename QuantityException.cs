using System;

namespace BookStoreManagement.CustomExceptions
{
    public class QuantityException : Exception
    {
        public QuantityException(string Message) : base(Message)
        {

        }

        public QuantityException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
