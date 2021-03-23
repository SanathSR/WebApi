using System;

namespace BookStoreManagement.CustomExceptions
{
    public class SqlExceptions : Exception
    {
        public SqlExceptions(string Message) : base(Message)
        {

        }

        public SqlExceptions(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
