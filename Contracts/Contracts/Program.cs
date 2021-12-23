using System;
using System.Globalization;
using Contracts.Entities;
using Contracts.Services;

namespace Contracts
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write(" Enter number of installments:");
            int numberOfInstallments = int.Parse(Console.ReadLine());

            var contract = new Contract(number, date, value);

            var contractService = new ContractService(contract, new PayPaymentService());
            contractService.Installments(numberOfInstallments);

            Console.WriteLine("Installments: ");

            foreach (var installment in contract.Installments)
            {
                Console.WriteLine(installment);
            }
        }
    }
}
