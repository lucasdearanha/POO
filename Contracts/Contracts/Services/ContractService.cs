using Contracts.Entities;

namespace Contracts.Services
{
    public class ContractService
    {
        private readonly Contract _contract;
        private readonly IPaymentService _paymentService;

        public ContractService(Contract contract, IPaymentService paymentService)
        {
            _contract = contract;
            _paymentService = paymentService;
        }

        public void Installments(int totalInstallments)
        {
            for (int currentMonth = 1; currentMonth <= totalInstallments; currentMonth++)
            {
                var date = _contract.DateOfContract;

                var installment = new Installment(date.AddMonths(currentMonth), 
                    _paymentService.TaxPayment(_contract.ContractValue / totalInstallments, currentMonth));

                _contract.AddInstallment(installment);
            }
        }
    }
}
