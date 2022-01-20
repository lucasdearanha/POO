using AccountExcep.Entities.Exceptions;

namespace AccountExcep.Entities
{
    public class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public decimal Balance { get; set; }
        public decimal WithdrawLimit { get; set; }

        public Account(int number, string holder, decimal initialDeposit, decimal withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Deposit(initialDeposit);
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > WithdrawLimit)
                throw new AccountWithdrawException("The amount exceeds withdraw limit");
            if (Balance < amount)
                throw new AccountWithdrawException("Not enough balance");

            Balance -= amount;
        }
    }
}
