using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagement.CustomExceptions
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException(string Message) : base(Message)
        {

        }

        public UserNotFoundException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
