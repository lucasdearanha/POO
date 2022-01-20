using System;
using System.Globalization;
using AccountExcep.Entities;
using AccountExcep.Entities.Exceptions;

namespace AccountExcep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string name = Console.ReadLine();
                Console.Write("Initial balance: ");
                decimal initialBalance = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                decimal withdrawLimit = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                var account = new Account(number, name, initialBalance, withdrawLimit);
                Console.Write("Enter the amount for withdraw: ");
                decimal withdraw = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                account.Withdraw(withdraw);
                Console.WriteLine($"New balance: {account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            catch (AccountWithdrawException exception)
            {
                Console.WriteLine($"Error withdraw: {exception.Message}");
            }
            catch (FormatException exception)
            {
                Console.WriteLine($"Invalid data: {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
