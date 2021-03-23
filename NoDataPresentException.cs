using System;

namespace BookStoreManagement.CustomExceptions
{
    public class NoDataPresentException : Exception
    {
        public NoDataPresentException(string Message) : base(Message)
        {

        }

        public NoDataPresentException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
