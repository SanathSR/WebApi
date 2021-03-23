using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagement.CustomExceptions
{
    public class TransactionIdInvalidException :Exception
    {
        public TransactionIdInvalidException(string Message) : base(Message)
        {

        }

        public TransactionIdInvalidException(string Message, Exception innerException) : base(Message, innerException)
        {

        }
    }
}
