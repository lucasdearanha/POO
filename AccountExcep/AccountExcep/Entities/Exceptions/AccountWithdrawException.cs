using System;

namespace AccountExcep.Entities.Exceptions
{
    public class AccountWithdrawException : ApplicationException
    {
        public AccountWithdrawException(string message) : base(message)
        {
        }
    }
}
