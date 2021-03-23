using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagement.CustomExceptions
{
    public class DuplicateUserNameException:Exception
    {
        public DuplicateUserNameException(string Message) : base(Message)
        {

        }

        public DuplicateUserNameException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
